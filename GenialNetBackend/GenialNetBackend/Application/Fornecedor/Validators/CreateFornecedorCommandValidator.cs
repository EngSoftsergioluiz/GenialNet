using FluentValidation;
using GenialNetBackend.Application.Fornecedor.Commands;
using GenialNetBackend.Persistence;
using GenialNetBackend.Utils;
using Microsoft.EntityFrameworkCore;

namespace GenialNetBackend.Application.Fornecedor.Validators
{
    public class CreateFornecedorCommandValidator : AbstractValidator<CreateFornecedorCommand>
    {
        private readonly ApplicationDbContext _context;
        public CreateFornecedorCommandValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage("CNPJ é obrigatório.")
                .Must(CnpjValidator.ValidarCNPJ).WithMessage("CNPJ é inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.");

            RuleFor(x => x.CEPEndereco)
                .NotEmpty().WithMessage("CEP é obrigatório.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório.");

            RuleFor(x => x.ProdutosIds)
                .NotEmpty().WithMessage("ProdutosIds é obrigatório.")
                .Must(ids => !ids.Contains(0)).WithMessage("Não existe ProdutosIds com o valor 0.");

            RuleFor(x => x)
                .MustAsync(FornecedorUnico).WithMessage("Já existe um fornecedor com estes dados");
        }

        private async Task<bool> FornecedorUnico(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedorExistente = await _context.Fornecedores
                                                .Where(f => f.CNPJ == request.CNPJ && f.Nome == request.Nome && f.Telefone == request.Telefone)
                                                .FirstOrDefaultAsync(cancellationToken);

            if (fornecedorExistente != null)
            {
                // Verifica se os produtos do fornecedor existente são os mesmos dos produtos enviados.
                var produtosExistenteIds = fornecedorExistente.Produtos.Select(p => p.Id).ToList();
                var produtosIdsRequest = request.ProdutosIds;

                // Retorna true se os IDs forem diferentes, ou seja, fornecedor único.
                return !produtosExistenteIds.SequenceEqual(produtosIdsRequest);
            }
            // Nenhum fornecedor encontrado com os mesmos dados
            return true;
        }
    }
}
using FluentValidation;
using GenialNetBackend.Application.Fornecedor.Repository;
using GenialNetBackend.Persistence;
using GenialNetBackend.Services;
using GenialNetBackend.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GenialNetBackend.Application.Fornecedor.Commands.Handler
{
    public class CreateFornecedorCommandHandler : IRequestHandler<CreateFornecedorCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly FornecedorRepository _fornecedorRepository;
        private readonly ViaCepService _viaCepService;
        private readonly IValidator<CreateFornecedorCommand> _validator;

        public CreateFornecedorCommandHandler(ApplicationDbContext context, FornecedorRepository fornecedorRepository, ViaCepService viaCepService, IValidator<CreateFornecedorCommand> validator)
        {
            _context = context;
            _fornecedorRepository = fornecedorRepository;
            _viaCepService = viaCepService;
            _validator = validator;
        }

        public async Task<int> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (!CnpjValidator.ValidarCNPJ(request.CNPJ))
            {
                throw new System.Exception("CNPJ inválido!");
            }

            if (await _fornecedorRepository.ExisteFornecedorComCNPJ(request.CNPJ))
            {
                throw new System.Exception("Fornecedor já cadastrado!");
            }

            if (string.IsNullOrWhiteSpace(request.CEPEndereco))
            {
                throw new System.Exception("O CEP é obrigatório para buscar o endereço!");
            }

            var endereco = await _viaCepService.BuscarEnderecoPorCep(request.CEPEndereco);

            if (string.IsNullOrWhiteSpace(endereco) || endereco == "Endereço não encontrado")
            {
                throw new System.Exception("Não foi possível encontrar um endereço para o CEP informado.");
            }

            var produtos = await _context.Produtos
                .Where(p => request.ProdutosIds.Contains(p.Id))
                .ToListAsync(cancellationToken);

            var fornecedor = new GenialNetBackend.Domain.Fornecedor
            {
                Nome = request.Nome,
                CNPJ = request.CNPJ,
                Endereco = endereco,
                Telefone = request.Telefone,
                Produtos = produtos
            };

            await _fornecedorRepository.AdicionarFornecedorAsync(fornecedor);
            return fornecedor.Id;
        }
    }
}

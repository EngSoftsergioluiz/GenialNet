using FluentValidation;
using GenialNetBackend.Application.Fornecedor.Commands;
using GenialNetBackend.Application.Produtos.Commands;
using GenialNetBackend.Persistence;
using GenialNetBackend.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GenialNetBackend.Application.Fornecedor.Validators
{
    public class UpdateProdutosFornecedorCommandValidator : AbstractValidator<UpdateProdutosFornecedorCommand>
    {
        private readonly ApplicationDbContext _context;
        public UpdateProdutosFornecedorCommandValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.FornecedorId)
                .NotEmpty().WithMessage("FornecedorId é obrigatório.");

            RuleFor(x => x.ProdutosIds)
                .NotEmpty().WithMessage("ProdutosIds é obrigatório.")
                .Must(ids => !ids.Contains(0)).WithMessage("Não existe ProdutosIds com o valor 0.")
                .MustAsync(ProdutosExistem).WithMessage("Um ou mais produtos não existem.");
        }
        private async Task<bool> ProdutosExistem(List<int> produtosIds, CancellationToken cancellationToken)
        {
            var produtosExistentes = await _context.Produtos
                .Where(p => produtosIds.Contains(p.Id))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            return produtosExistentes.Count == produtosIds.Count;
        }
    }
}

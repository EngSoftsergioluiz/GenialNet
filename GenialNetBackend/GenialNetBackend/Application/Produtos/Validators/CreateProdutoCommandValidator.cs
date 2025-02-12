using FluentValidation;
using GenialNetBackend.Application.Produtos.Commands;
using GenialNetBackend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GenialNetBackend.Application.Produtos.Validators
{
    public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
    {
        private readonly ApplicationDbContext _context;

        public CreateProdutoCommandValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.");

            RuleFor(p => p.Marca)
                .NotEmpty().WithMessage("A marca é obrigatória.");

            RuleFor(p => p.UnidadeMedida)
                .NotEmpty().WithMessage("A unidade de medida é obrigatória.")
                .Must(u => new List<string> { "unidade", "quilograma", "metro" }.Contains(u.ToLower()))
                .WithMessage("Unidade de medida inválida.");

            RuleFor(p => p)
                .MustAsync(ProdutoUnico).WithMessage("Já existe um produto com essa descrição e marca.");
        }

        private async Task<bool> ProdutoUnico(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            return !await _context.Produtos
                .AnyAsync(p => p.Descricao == request.Descricao && p.Marca == request.Marca, cancellationToken);
        }
    }
}
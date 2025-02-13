using FluentValidation;
using GenialNetBackend.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GenialNetBackend.Application.Fornecedor.Commands.Handler
{
    public class UpdateProdutosFornecedorCommandHandler : IRequestHandler<UpdateProdutosFornecedorCommand, bool>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<UpdateProdutosFornecedorCommand> _validator;

        public UpdateProdutosFornecedorCommandHandler(ApplicationDbContext context, IValidator<UpdateProdutosFornecedorCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<bool> Handle(UpdateProdutosFornecedorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var fornecedor = await _context.Fornecedores
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == request.FornecedorId, cancellationToken);

            if (fornecedor == null)
            {
                throw new System.Exception("Fornecedor não encontrado");
            }

            var produtos = await _context.Produtos
                .Where(p => request.ProdutosIds.Contains(p.Id))
                .ToListAsync(cancellationToken);

            fornecedor.Produtos = produtos;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

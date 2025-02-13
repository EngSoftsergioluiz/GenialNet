using GenialNetBackend.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GenialNetBackend.Application.Fornecedor.Commands.Handler
{
    public class RemoveProdutoFornecedorCommandHandler : IRequestHandler<RemoveProdutoFornecedorCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public RemoveProdutoFornecedorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RemoveProdutoFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = await _context.Fornecedores
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == request.FornecedorId, cancellationToken);

            if (fornecedor == null)
            {
                return false;
            }

            // Removendo os produtos do fornecedor
            fornecedor.Produtos.RemoveAll(p => request.ProdutosIds.Contains(p.Id));

            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

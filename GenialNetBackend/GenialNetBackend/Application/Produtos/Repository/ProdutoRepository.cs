using GenialNetBackend.Domain;
using GenialNetBackend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GenialNetBackend.Application.Produtos.Repository
{
    public class ProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Produto> GetProdutos()
        {
            return _context.Produtos.FromSqlRaw("EXEC GetProdutos").ToList();
        }
    }
}

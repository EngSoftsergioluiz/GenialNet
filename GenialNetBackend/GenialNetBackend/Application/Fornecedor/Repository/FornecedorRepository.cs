using GenialNetBackend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GenialNetBackend.Application.Fornecedor.Repository
{
    public class FornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GenialNetBackend.Domain.Fornecedor>> GetFornecedoresAsync()
        {
            return await _context.Fornecedores.Include(f => f.Produtos).ToListAsync();
        }

        public async Task<GenialNetBackend.Domain.Fornecedor> GetFornecedorByIdAsync(int id)
        {
            return await _context.Fornecedores.Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> ExisteFornecedorComCNPJ(string cnpj)
        {
            return await _context.Fornecedores.AnyAsync(f => f.CNPJ == cnpj);
        }

        public async Task AdicionarFornecedorAsync(GenialNetBackend.Domain.Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarFornecedorAsync(GenialNetBackend.Domain.Fornecedor fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverFornecedorAsync(GenialNetBackend.Domain.Fornecedor fornecedor)
        {
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
        }
    }
}

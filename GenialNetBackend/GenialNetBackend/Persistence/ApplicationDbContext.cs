using GenialNetBackend.Domain;
using Microsoft.EntityFrameworkCore;

namespace GenialNetBackend.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasIndex(p => p.Descricao)
                .IsUnique();

            modelBuilder.Entity<Fornecedor>()
                .HasIndex(f => f.CNPJ)
                .IsUnique();
        }
    }
}

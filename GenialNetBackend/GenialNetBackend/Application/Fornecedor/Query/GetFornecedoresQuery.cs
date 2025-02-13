using GenialNetBackend.Application.Fornecedor.DTOs;
using GenialNetBackend.Application.Produtos.DTOs;
using GenialNetBackend.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GenialNetBackend.Application.Fornecedor.Query
{
    public class GetFornecedoresQuery : IRequest<List<FornecedorDto>>
    {
    }

    public class GetFornecedoresQueryHandler : IRequestHandler<GetFornecedoresQuery, List<FornecedorDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetFornecedoresQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FornecedorDto>> Handle(GetFornecedoresQuery request, CancellationToken cancellationToken)
        {
            var fornecedores = await _context.Fornecedores
                .Include(f => f.Produtos)  // Carregar os produtos associados
                .Select(f => new FornecedorDto
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    CNPJ = f.CNPJ,
                    Endereco = f.Endereco,
                    Telefone = f.Telefone,
                    Produtos = f.Produtos.Select(p => new ProdutoDto
                    {
                        Id = p.Id,
                        Descricao = p.Descricao,
                        Marca = p.Marca,
                        UnidadeMedida = p.UnidadeMedida
                    }).ToList()
                })
                .ToListAsync(cancellationToken);

            return fornecedores;
        }
    }
}

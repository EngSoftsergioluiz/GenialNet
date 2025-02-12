using GenialNetBackend.Application.Produtos.Repository;
using GenialNetBackend.Domain;
using MediatR;

namespace GenialNetBackend.Application.Produtos.Query
{
    public class GetProdutosQuery : IRequest<List<Produto>>
    {
    }

    public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, List<Produto>>
    {
        private readonly ProdutoRepository _produtoRepository;

        public GetProdutosQueryHandler(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<Produto>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _produtoRepository.GetProdutos(), cancellationToken);
        }
    }
}

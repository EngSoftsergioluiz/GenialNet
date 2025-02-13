using MediatR;

namespace GenialNetBackend.Application.Fornecedor.Commands
{
    public class UpdateProdutosFornecedorCommand : IRequest<bool>
    {
        public int FornecedorId { get; set; }
        public List<int> ProdutosIds { get; set; } = new();
    }

}

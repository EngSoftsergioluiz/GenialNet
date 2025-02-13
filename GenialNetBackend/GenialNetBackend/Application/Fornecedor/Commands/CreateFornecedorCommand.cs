using MediatR;

namespace GenialNetBackend.Application.Fornecedor.Commands
{
    public class CreateFornecedorCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string CEPEndereco { get; set; }
        public string Telefone { get; set; }
        public List<int> ProdutosIds { get; set; } = new();
    }

}
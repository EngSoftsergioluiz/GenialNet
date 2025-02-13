using GenialNetBackend.Application.Produtos.DTOs;

namespace GenialNetBackend.Application.Fornecedor.DTOs
{
    public class FornecedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public List<ProdutoDto> Produtos { get; set; } = new();
    }
}

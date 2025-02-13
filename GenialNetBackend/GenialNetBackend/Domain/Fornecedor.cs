using GenialNetBackend.Utils;

namespace GenialNetBackend.Domain
{
    public class Fornecedor
    {
        private string _cnpj;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ 
        {
            get => _cnpj;
            set => _cnpj = CnpjValidator.FormatarCNPJ(value);
        }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public List<Produto> Produtos { get; set; } = new();
    }
}

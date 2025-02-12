using GenialNetBackend.Domain;
using GenialNetBackend.Persistence;
using GenialNetBackend.Utils;
using MediatR;

namespace GenialNetBackend.Application.Fornecedor.Commands
{
    public class CreateFornecedorCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public List<Produto> Produtos { get; set; } = new();
    }

    public class CreateFornecedorCommandHandler : IRequestHandler<CreateFornecedorCommand, int>
    {
        private readonly ApplicationDbContext _context;
        public CreateFornecedorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            if (!CnpjValidator.ValidarCNPJ(request.CNPJ))
            {
                throw new Exception("CNPJ inválido");
            }
                
            var fornecedor = new GenialNetBackend.Domain.Fornecedor 
            {
                Nome = request.Nome,
                CNPJ = request.CNPJ,
                Endereco = request.Endereco,
                Telefone = request.Telefone,
                Produtos = request.Produtos
            };
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync(cancellationToken);
            return fornecedor.Id;
        }

        public class ViaCepService
        {
            private readonly HttpClient _httpClient;

            public ViaCepService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<string> BuscarEndereco(string cep)
            {
                var response = await _httpClient.GetFromJsonAsync<ViaCepResponse>($"https://viacep.com.br/ws/{cep}/json/");
                return response?.Logradouro ?? "Endereço não encontrado";
            }
        }

        public class ViaCepResponse
        {
            public string Logradouro { get; set; }
        }
    }
}

namespace GenialNetBackend.Services
{
    public class ViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> BuscarEnderecoPorCep(string cep)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ViaCepResponse>($"https://viacep.com.br/ws/{cep}/json/");

                if (response == null || string.IsNullOrEmpty(response.Logradouro))
                    return "Endereço não encontrado";

                return $"{response.Logradouro}, {response.Bairro}, {response.Localidade} - {response.Uf}";
            }
            catch
            {
                return "Erro ao buscar endereço";
            }
        }
    }

    public class ViaCepResponse
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
    }

}

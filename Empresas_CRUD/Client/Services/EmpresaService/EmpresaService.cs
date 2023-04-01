using System.Net.Http.Json;

namespace Empresas_CRUD.Client.Services.EmpresaService
{
    //A classe Empresa Service é uma implementação da classe IEmpresaService (interface)
    public class EmpresaService : IEmpresaService
    {
        private readonly HttpClient _http;

        public EmpresaService(HttpClient http)
        {
            _http = http;
        }
        public List<Empresas> Empresas { get; set; } = new List<Empresas>();
        public List<Segmentos> Segmentos { get; set; } = new List<Segmentos>();

        public async Task GetEmpresas()
        {
            var resultado = await _http.GetFromJsonAsync<List<Empresas>>("api/empresas");

            if (resultado != null)
                Empresas = resultado;
        }

        public Task GetSegmentos()
        {
            throw new NotImplementedException();
        }

        public Task<Empresas> GetSingleEmpresa(int id)
        {
            throw new NotImplementedException();
        }
    }
}

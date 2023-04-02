using Empresas_CRUD.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Empresas_CRUD.Client.Services.EmpresaService
{
    //A classe Empresa Service é uma implementação da classe IEmpresaService (interface)
    public class EmpresaService : IEmpresaService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        //construtor da classe
        public EmpresaService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;

        }
        public List<Empresas> Empresas { get; set; } = new List<Empresas>();
        public List<Segmentos> Segmentos { get; set; } = new List<Segmentos>();

        private async Task SetEmpresa(HttpResponseMessage resultado)
        {
            var resposta = await resultado.Content.ReadFromJsonAsync<List<Empresas>>();
            Empresas = resposta;
            _navigationManager.NavigateTo("listar-empresas");
        }

        public async Task CreateEmpresa(Empresas empresa)
        {
            var resultado = await _http.PostAsJsonAsync("api/empresas", empresa);
            await SetEmpresa(resultado);
        }

        public async Task DeleteEmpresa(int id)
        {
            var resultado = await _http.DeleteAsync($"api/empresas/{id}");
            await SetEmpresa(resultado);
        }

        public async Task GetEmpresas()
        {
            var resultado = await _http.GetFromJsonAsync<List<Empresas>>("api/empresas");

            if (resultado != null)
                Empresas = resultado;
        }

        public async Task GetSegmentos()
        {
            var resultado = await _http.GetFromJsonAsync<List<Segmentos>>("api/empresas/segmentos");

            if (resultado != null)
                Segmentos = resultado;
        }

        public async Task<Empresas> GetSingleEmpresa(int id)
        {
            var resultado = await _http.GetFromJsonAsync<Empresas>($"api/empresas/{id}");

            if (resultado != null)
                return resultado;
            throw new Exception("Empresa não encontada");
        }

        public async Task UpdateEmpresa(Empresas empresa)
        {
            var resultado = await _http.PutAsJsonAsync($"api/empresas/{empresa.Id}", empresa);
            await SetEmpresa(resultado);
        }
    }
}

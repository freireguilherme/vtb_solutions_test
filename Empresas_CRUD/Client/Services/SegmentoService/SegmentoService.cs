using Empresas_CRUD.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Empresas_CRUD.Client.Services.SegmentoService
{
    public class SegmentoService : ISegmentoService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public SegmentoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Segmentos> Segmentos { get; set; } = new List<Segmentos>();

        private async Task SetSegmento (HttpResponseMessage resultado)
        {
            var resposta = await resultado.Content.ReadFromJsonAsync<List<Segmentos>>();
            Segmentos = resposta;
            _navigationManager.NavigateTo("listar-segmentos");
        }
        public async Task CreateSegmento(Segmentos segmento)
        {
            var resultado = await _http.PostAsJsonAsync("api/segmentos", segmento);
            await SetSegmento(resultado);
        }

        public Task DeleteSegmento(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetSegmentos()
        {
            var resultado = await _http.GetFromJsonAsync<List<Segmentos>>("api/segmentos");

            if (resultado != null)
                Segmentos = resultado;
        }

        public async Task<Segmentos> GetSingleSegmento(int id)
        {
            var resultado = await _http.GetFromJsonAsync<Segmentos>($"api/segmentos/{id}");

            if (resultado != null)
                return resultado;
            throw new Exception("Empresa não encontada");
        }

        public async Task UpdateSegmento(Segmentos segmento)
        {
            var resultado = await _http.PutAsJsonAsync($"api/segmentos/{segmento.Id}", segmento);
            await SetSegmento(resultado);
        }
    }
}

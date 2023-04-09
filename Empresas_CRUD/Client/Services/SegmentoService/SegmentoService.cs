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

        public Task GetSegmentos()
        {
            throw new NotImplementedException();
        }

        public Task<Segmentos> GetSingleSegmento(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSegmento(Segmentos segmento)
        {
            throw new NotImplementedException();
        }
    }
}

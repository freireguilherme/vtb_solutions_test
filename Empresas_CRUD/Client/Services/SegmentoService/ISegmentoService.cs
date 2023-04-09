using Empresas_CRUD.Shared;

namespace Empresas_CRUD.Client.Services.SegmentoService
{
    public interface ISegmentoService
    {
        
        List<Segmentos> Segmentos { get; set; }

        Task GetSegmentos();

        Task<Segmentos> GetSingleSegmento(int id);

        Task CreateSegmento(Segmentos segmento);
        Task UpdateSegmento(Segmentos segmento);
        Task DeleteSegmento(int id);
    }
}

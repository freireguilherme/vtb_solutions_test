namespace Empresas_CRUD.Client.Services.SegmentoService
{
    public class SegmentoService : ISegmentoService
    {
        public List<Segmentos> Segmentos { get; set; } = new List<Segmentos>();

        public Task CreateSegmento(Segmentos segmento)
        {
            throw new NotImplementedException();
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

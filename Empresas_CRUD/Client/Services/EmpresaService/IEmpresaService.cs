
namespace Empresas_CRUD.Client.Services.EmpresaService
{
    public interface IEmpresaService
    {
        List<Empresas> Empresas { get; set; }
        List<Segmentos> Segmentos { get; set; }

        Task GetSegmentos();
        Task GetEmpresas();

        Task<Empresas> GetSingleEmpresa(int id);

        Task CreateEmpresa(Empresas empresa);
        Task UpdateEmpresa(Empresas empresa);
        Task DeleteEmpresa(int id);
    }
}

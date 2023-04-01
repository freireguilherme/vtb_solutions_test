using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresas_CRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        //alguns mocks
        public static List<Segmentos> segmentos = new List<Segmentos> { };
    }
}

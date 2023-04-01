using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresas_CRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        //alguns mocks
        public static List<Segmentos> segmentos = new List<Segmentos> {
            new Segmentos { Id = 1, Nome = "Indústria"},
            new Segmentos { Id = 2, Nome = "Tecnologia"}
        };

        public static List<Empresas> empresas = new List<Empresas> {
            new Empresas {
                Id = 1,
                Nome = "ACME",
                Site = "https://acme.com",
                Segmento = segmentos[0]
            },
            new Empresas {
                Id = 2,
                Nome = "Google",
                Site = "https://google.com",
                Segmento = segmentos[1]
            }
        };
        //funções.
        //Aqui queremos receber uma lista de todas as empresas
        [HttpGet]
        public async Task<ActionResult<List<Empresas>>> GetEmpresas()
        {
            return Ok(empresas);
        }

        //Agora queremos receber uma empresa com base no ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresas>> GetSingleEmpresa(int id)
        {
            var empresa = empresas.FirstOrDefault(e => e.Id == id);
            if (empresa == null)
            {
                return NotFound("Desculpa, empresa não encontrada");
            }
            return Ok(empresa);
        }


    }
}

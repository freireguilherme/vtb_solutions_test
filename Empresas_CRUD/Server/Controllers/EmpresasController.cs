using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresas_CRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        //mocks removidos, agora conseguimos os dados do database

        //construtor
        private readonly DataContex _context;

        public EmpresasController(DataContex context)
        {
            _context = context;
        }

        //funções.
        //Aqui queremos receber uma lista de todas as empresas
        [HttpGet]
        public async Task<ActionResult<List<Empresas>>> GetEmpresas()
        {
            var empresas = await _context.Empresas
                .Include(e => e.Segmento) //incluir o segmento, ou caso contrario retorna null
                .ToListAsync();
            return Ok(empresas);
        }

        [HttpGet("segmentos")]
        public async Task<ActionResult<List<Segmentos>>> GetSegmentos()
        {
            var segmentos = await _context.Segmentos.ToListAsync();
            return Ok(segmentos);
        }

        //Agora queremos receber uma empresa com base no ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresas>> GetSingleEmpresa(int id)
        {
            var empresa = await _context.Empresas
                .Include(e => e.Segmento) //incluimos o relacionamento com segmentos, ou caso contrário retornaria uma empresa com segmento nulo
                .FirstOrDefaultAsync(e => e.Id == id);
            if (empresa == null)
            {
                return NotFound("Desculpa, empresa não encontrada");
            }
            return Ok(empresa);
        }
        
        // metodo privaddo que acessa o db e retorna uma lista de empresas
        // ao fim das funçõs get, update e delete, esse metodo é usado para
        // retornar a lista de empresas atual
        private async Task<List<Empresas>> GetDbEmpresas()
        {
            return await _context.Empresas.Include(e => e.Segmento).ToListAsync();
        }

        //criar uma empresa
        [HttpPost]
        public async Task<ActionResult<List<Empresas>>> CreateEmpresa(Empresas empresa)
        {
            empresa.Segmento = null;

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return Ok(await GetDbEmpresas());
        }

        //atualizar uma empresa
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Empresas>>> UpdateEmpresa(Empresas empresa, int id)
        {
            var dbEmpresa = await _context.Empresas
                .Include(e => e.Segmento)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (dbEmpresa == null)
                return NotFound("Desculpa, empresa não encontrada");

            //override 
            dbEmpresa.Nome = empresa.Nome;
            dbEmpresa.Site = empresa.Site;
            dbEmpresa.SegmentoId = empresa.SegmentoId;
            
            await _context.SaveChangesAsync();

            return Ok(await GetDbEmpresas());
        }

        //deletar uma empresa
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Empresas>>> DeleteEmpresa(int id)
        {
            var dbEmpresa = await _context.Empresas
                .Include(e => e.Segmento)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (dbEmpresa == null)
                return NotFound("Desculpa, empresa não encontrada");

            _context.Empresas.Remove(dbEmpresa);

            await _context.SaveChangesAsync();

            return Ok(await GetDbEmpresas());
        }
    }
}

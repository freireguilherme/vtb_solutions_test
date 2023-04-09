using Empresas_CRUD.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresas_CRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentosController : ControllerBase
    {
        //construtor
        private readonly DataContex _context;

        public SegmentosController(DataContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Segmentos>>> GetSegmentos()
        {
            var segmentos = await _context.Segmentos.ToListAsync();
            return Ok(segmentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Segmentos>> GetSingleSegmento (int id)
        {
            var segmento = await _context.Segmentos.FirstOrDefaultAsync(s => s.Id == id);
            if (segmento == null)
                return NotFound("Desculpa, segmento não encontrado");
            return Ok(segmento);
        }

        private async Task<List<Segmentos>> GetDbSegmentos()
        {
            return await _context.Segmentos.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<List<Segmentos>>> CreateSemento( Segmentos segmento)
        {

            _context.Segmentos.Add(segmento);
            await _context.SaveChangesAsync();

            return Ok(await GetDbSegmentos());
        }
    }
}

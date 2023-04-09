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
    }
}

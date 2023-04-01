using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresas_CRUD.Shared
{
    public class Empresas
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Site { get; set; } = string.Empty;

        public Segmentos? Segmento { get; set; }

        public int SegmentoId { get; set; }
    }
}

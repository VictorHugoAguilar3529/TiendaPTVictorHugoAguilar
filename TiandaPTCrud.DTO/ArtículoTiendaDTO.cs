using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiandaPTCrud.DTO
{
    public class ArtículoTiendaDTO
    {
        public int ArtículoId { get; set; }
        public int TiendaId { get; set; }
        public DateTime? Fecha { get; set; }
        public virtual ArtículoDTO Artículo { get; set; } = null!;
        public virtual ArtículoTiendaDTO Tienda { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiandaPTCrud.DTO
{
    public class ClienteArtículoDTO
    {
        public int ClienteId { get; set; }
        public int ArtículoId { get; set; }
        public DateTime? Fecha { get; set; }
        public virtual ArtículoDTO Artículo { get; set; } = null!;
        public virtual ClienteDTO Cliente { get; set; } = null!;
    }
}

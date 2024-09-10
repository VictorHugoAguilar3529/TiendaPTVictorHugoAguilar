using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiandaPTCrud.DTO
{
    public class ArtículoDTO
    {
        public int ArtículoId { get; set; }
        public string? Código { get; set; }
        public string? Descripción { get; set; }
        public decimal? Precio { get; set; }
        public string? Imagen { get; set; }
        public int? Stock { get; set; }


        public virtual ICollection<ArtículoTiendaDTO> ArtículoTienda { get; set; }
        public virtual ICollection<ClienteArtículoDTO> ClienteArtículos { get; set; }
    }
}

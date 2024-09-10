using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiandaPTCrud.DTO
{
    public class TiendaDTO
    {
        public int TiendaId { get; set; }
        public string? Sucursal { get; set; }
        public string? Dirección { get; set; }
        public virtual ICollection<ArtículoTiendaDTO> ArtículoTienda { get; set; }

        public static implicit operator TiendaDTO(bool v)
        {
            throw new NotImplementedException();
        }
    }
}

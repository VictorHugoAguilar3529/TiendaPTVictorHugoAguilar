using System;
using System.Collections.Generic;

namespace TiandaPTCrud.Models
{
    public partial class Tiendum
    {


        public int TiendaId { get; set; }
        public string? Sucursal { get; set; }
        public string? Dirección { get; set; }

        public virtual ICollection<ArtículoTiendum> ArtículoTienda { get; set; }
    }
}

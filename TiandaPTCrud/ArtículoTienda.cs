using System;
using System.Collections.Generic;

namespace TiandaPTCrud.Models
{
    public partial class ArtículoTiendum
    {
        public int ArtículoId { get; set; }
        public int TiendaId { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Artículo Artículo { get; set; } = null!;
        public virtual Tiendum Tienda { get; set; } = null!;
    }
}

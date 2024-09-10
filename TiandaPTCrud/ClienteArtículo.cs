using System;
using System.Collections.Generic;

namespace TiandaPTCrud.Models
{
    public partial class ClienteArtículo
    {
        public int ClienteId { get; set; }
        public int ArtículoId { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Artículo Artículo { get; set; } = null!;
        public virtual Cliente Cliente { get; set; } = null!;
    }
}

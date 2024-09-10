using System;
using System.Collections.Generic;

namespace TiandaPTCrud.Models
{
    public partial class Artículo
    {

        public int ArtículoId { get; set; }
        public string? Código { get; set; }
        public string? Descripción { get; set; }
        public decimal? Precio { get; set; }
        public string? Imagen { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<ArtículoTiendum> ArtículoTienda { get; set; }
        public virtual ICollection<ClienteArtículo> ClienteArtículos { get; set; }

        public static implicit operator Artículo(ArtículoTiendum v)
        {
            throw new NotImplementedException();
        }
    }
}

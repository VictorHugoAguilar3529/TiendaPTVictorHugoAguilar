using System;
using System.Collections.Generic;

namespace TiandaPTCrud.Models
{
    public partial class Cliente
    {
        
        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Dirección { get; set; }

        public virtual ICollection<ClienteArtículo> ClienteArtículos { get; set; }
    }
}

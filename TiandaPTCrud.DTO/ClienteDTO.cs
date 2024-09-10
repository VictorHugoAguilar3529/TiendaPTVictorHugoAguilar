using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiandaPTCrud.DTO
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Dirección { get; set; }

        public static implicit operator ClienteDTO(bool v)
        {
            throw new NotImplementedException();
        }
    }
}

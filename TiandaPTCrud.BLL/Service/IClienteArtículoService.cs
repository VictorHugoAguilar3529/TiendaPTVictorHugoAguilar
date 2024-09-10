using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.BLL.Service
{
    public interface IClienteArtículoService
    {
        Task<bool> Insertar(ClienteArtículo modelo);
        Task<bool> Actualizar(ClienteArtículo modelo);
        Task<bool> Eliminar(int id);
        Task<ClienteArtículo> Obtener(int id);
        Task<IQueryable<ClienteArtículo>> ObtenerTodos();
    }
}

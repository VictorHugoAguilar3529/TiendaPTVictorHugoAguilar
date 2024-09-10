using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.BLL.Service
{
    public interface IArtículoTiendaService
    {
        Task<bool> Insertar(ArtículoTiendum modelo);
        Task<bool> Actualizar(ArtículoTiendum modelo);
        Task<bool> Eliminar(int id);
        Task<ArtículoTiendum> Obtener(int id);
        Task<IQueryable<ArtículoTiendum>> ObtenerTodos();
    }
}

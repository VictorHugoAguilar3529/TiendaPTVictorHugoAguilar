using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.BLL.Service
{
    public interface ITiendaService
    {
        Task<bool> Insertar(Tiendum modelo);
        Task<bool> Actualizar(Tiendum modelo);
        Task<bool> Eliminar(int id);
        Task<Tiendum> Obtener(int id);
        Task<IQueryable<Tiendum>> ObtenerTodos();
    }
}

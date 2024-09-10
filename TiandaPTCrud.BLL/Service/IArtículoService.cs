using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.BLL.Service
{
    public interface IArtículoService
    {
        Task<bool> Insertar(Artículo modelo);
        Task<bool> Actualizar(Artículo modelo);
        Task<bool> Eliminar(int id);
        Task<Artículo> Obtener(int id);
        Task<IQueryable<Artículo>> ObtenerTodos();
    }
}

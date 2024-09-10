using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.DAL.DataContext;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.DAL.Repositories
{
    public class TiendaRepositiry : IGenericRepository<Tiendum>
    {
        private readonly tiendabdContext _bdcontext;

        public TiendaRepositiry(tiendabdContext context)
        {
            _bdcontext = context;
        }
        public async Task<bool> Actualizar(Tiendum modelo)
        {
            _bdcontext.Tienda.Update(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Tiendum modelo = _bdcontext.Tienda.First(c => c.TiendaId == id);
            _bdcontext.Tienda.Remove(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Tiendum modelo)
        {
            _bdcontext.Tienda.Add(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Tiendum> Obtener(int id)
        {
            return await _bdcontext.Tienda.FirstOrDefaultAsync(c => c.TiendaId == id);
        }

        public async Task<IQueryable<Tiendum>> ObtenerTodos()
        {
            IQueryable<Tiendum> queryTiendaSQL = _bdcontext.Tienda;
            return queryTiendaSQL;
        }
    }
}

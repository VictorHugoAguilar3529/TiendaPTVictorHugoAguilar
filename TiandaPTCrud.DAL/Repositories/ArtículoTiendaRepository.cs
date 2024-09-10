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
    internal class ArtículoTiendaRepository : IGenericRepository<ArtículoTiendum>
    {
        private readonly tiendabdContext _bdcontext;

        public ArtículoTiendaRepository(tiendabdContext context)
        {
            _bdcontext = context;
        }

        public async Task<bool> Actualizar(ArtículoTiendum modelo)
        {
            _bdcontext.ArtículoTienda.Update(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            ArtículoTiendum modelo = _bdcontext.ArtículoTienda.First(c => c.TiendaId == id);
            _bdcontext.ArtículoTienda.Remove(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(ArtículoTiendum modelo)
        {
            _bdcontext.ArtículoTienda.Add(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }


        public async Task<ArtículoTiendum> Obtener(int id)
        {
            return await _bdcontext.ArtículoTienda.FirstOrDefaultAsync(c => c.TiendaId == id);
        }

        public async Task<IQueryable<ArtículoTiendum>> ObtenerTodos()
        {
            IQueryable<ArtículoTiendum> queryArticuloTiendaSQL = _bdcontext.ArtículoTienda;
            return queryArticuloTiendaSQL;
        }
    }
}

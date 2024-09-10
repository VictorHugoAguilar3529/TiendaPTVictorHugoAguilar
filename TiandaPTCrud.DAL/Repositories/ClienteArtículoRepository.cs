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
    internal class ClienteArtículoRepository : IGenericRepository<ClienteArtículo>
    {
        private readonly tiendabdContext _bdcontext;

        public ClienteArtículoRepository(tiendabdContext context)
        {
            _bdcontext = context;
        }

        public async Task<bool> Actualizar(ClienteArtículo modelo)
        {
            _bdcontext.ClienteArtículos.Update(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            ClienteArtículo modelo = _bdcontext.ClienteArtículos.First(c => c.ClienteId == id);
            _bdcontext.ClienteArtículos.Remove(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(ClienteArtículo modelo)
        {
            _bdcontext.ClienteArtículos.Add(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<ClienteArtículo> Obtener(int id)
        {
            return await _bdcontext.ClienteArtículos.FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        public async Task<IQueryable<ClienteArtículo>> ObtenerTodos()
        {
            IQueryable<ClienteArtículo> queryClienteSQL = _bdcontext.ClienteArtículos;
            return queryClienteSQL;
        }
    }
}

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
    public class ClienteRepository : IGenericRepository<Cliente>
    {       
        private readonly tiendabdContext _bdcontext;

        public ClienteRepository(tiendabdContext context)
        {
            _bdcontext = context;
        }

        public async Task<bool> Actualizar(Cliente modelo)
        {
            _bdcontext.Clientes.Update(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Cliente modelo = _bdcontext.Clientes.First(c => c.ClienteId == id);
            _bdcontext.Clientes.Remove(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Cliente modelo)
        {
            _bdcontext.Clientes.Add(modelo);
            await _bdcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _bdcontext.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            IQueryable<Cliente> queryClienteSQL = _bdcontext.Clientes;
            return queryClienteSQL;
        }
    }
}

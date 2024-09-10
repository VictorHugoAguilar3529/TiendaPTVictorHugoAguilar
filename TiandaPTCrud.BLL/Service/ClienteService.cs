using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.DAL.Repositories;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.BLL.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepo;

        public ClienteService(IGenericRepository<Cliente> clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public async Task<bool> Actualizar(Cliente modelo)
        {
            return await _clienteRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _clienteRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Cliente modelo)
        {
            return await _clienteRepo.Insertar(modelo);
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _clienteRepo.Obtener(id);
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            return await _clienteRepo.ObtenerTodos();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.DAL.Repositories;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.BLL.Service
{
    public class ClienteArtículoService : IClienteArtículoService
    {
        private readonly IGenericRepository<ClienteArtículo> _clienteArticuloRepo;

        public ClienteArtículoService(IGenericRepository<ClienteArtículo> clienteArticuloRepo)
        {
            _clienteArticuloRepo = clienteArticuloRepo;
        }

        public async Task<bool> Actualizar(ClienteArtículo modelo)
        {
            return await _clienteArticuloRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _clienteArticuloRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(ClienteArtículo modelo)
        {
            return await _clienteArticuloRepo.Insertar(modelo);
        }

        public async Task<ClienteArtículo> Obtener(int id)
        {
            return await _clienteArticuloRepo.Obtener(id);
        }

        public async Task<IQueryable<ClienteArtículo>> ObtenerTodos()
        {
            return await _clienteArticuloRepo.ObtenerTodos();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.DAL.Repositories;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.BLL.Service
{
    public class TiendaService : ITiendaService
    {
        private readonly IGenericRepository<Tiendum> _tiendaRepo;

        public TiendaService(IGenericRepository<Tiendum> tiendaRepo)
        {
            _tiendaRepo = tiendaRepo;
        }

        public async Task<bool> Actualizar(Tiendum modelo)
        {
            return await _tiendaRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _tiendaRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Tiendum modelo)
        {
            return await _tiendaRepo.Insertar(modelo);
        }

        public async Task<Tiendum> Obtener(int id)
        {
            return await _tiendaRepo.Obtener(id);
        }

        public async Task<IQueryable<Tiendum>> ObtenerTodos()
        {
            return await _tiendaRepo.ObtenerTodos();
        }
    }
}

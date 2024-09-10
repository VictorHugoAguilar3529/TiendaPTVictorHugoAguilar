using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.DAL.Repositories;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.BLL.Service
{
    public class ArtículoTiendaService : IArtículoTiendaService
    {
        private readonly IGenericRepository<ArtículoTiendum> _articuloTiendaRepo;

        public ArtículoTiendaService(IGenericRepository<ArtículoTiendum> articuloTiendaRepo)
        {
            _articuloTiendaRepo = articuloTiendaRepo;
        }

        public async Task<bool> Actualizar(ArtículoTiendum modelo)
        {
            return await _articuloTiendaRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _articuloTiendaRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(ArtículoTiendum modelo)
        {
            return await _articuloTiendaRepo.Insertar(modelo);
        }

        public async Task<ArtículoTiendum> Obtener(int id)
        {
            return await _articuloTiendaRepo.Obtener(id);
        }

        public async Task<IQueryable<ArtículoTiendum>> ObtenerTodos()
        {
            return await _articuloTiendaRepo.ObtenerTodos();
        }
    }
}

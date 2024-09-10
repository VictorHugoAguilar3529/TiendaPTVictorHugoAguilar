using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiandaPTCrud.DAL.Repositories;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.BLL.Service
{
    public class ArtículoService : IArtículoService
    {
        private readonly IGenericRepository<Artículo> _articuloRepo;

        public ArtículoService(IGenericRepository<Artículo> articuloRepo)
        {
            _articuloRepo = articuloRepo;
        }

        public async Task<bool> Actualizar(Artículo modelo)
        {
            return await _articuloRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _articuloRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Artículo modelo)
        {
            return await _articuloRepo.Insertar(modelo);
        }

        public async Task<Artículo> Obtener(int id)
        {
            return await _articuloRepo.Obtener(id);
        }

        public async Task<IQueryable<Artículo>> ObtenerTodos()
        {
            return await _articuloRepo.ObtenerTodos();
        }
    }
}

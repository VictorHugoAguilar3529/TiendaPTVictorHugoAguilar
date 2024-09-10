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
    public class ArtículoRepositiry : IGenericRepository<Artículo>
    {
    private readonly tiendabdContext _bdcontext;

    public ArtículoRepositiry(tiendabdContext context)
    {
        _bdcontext = context;
    }

    public async Task<bool> Actualizar(Artículo modelo)
    {
        _bdcontext.Artículos.Update(modelo);
        await _bdcontext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Eliminar(int id)
    {
        Artículo modelo = _bdcontext.Artículos.First(c => c.ArtículoId == id);
        _bdcontext.Artículos.Remove(modelo);
        await _bdcontext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Insertar(Artículo modelo)
    {
        _bdcontext.Artículos.Add(modelo);
        await _bdcontext.SaveChangesAsync();
        return true;
    }

    public async Task<Artículo> Obtener(int id)
    {
        return await _bdcontext.Artículos.FirstOrDefaultAsync(c => c.ArtículoId == id);
    }

    public async Task<IQueryable<Artículo>> ObtenerTodos()
    {
        IQueryable<Artículo> queryArticuloSQL = _bdcontext.Artículos;
        return queryArticuloSQL;
    }
}
}

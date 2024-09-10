using TiandaPTCrud.DAL.DataContext;
using TiandaPTCrud.DAL.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly tiendabdContext _context;

    public GenericRepository(tiendabdContext context)
    {
        _context = context;
    }

    public Task<bool> Actualizar(TEntity modelo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Insertar(TEntity modelo)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Obtener(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TEntity>> ObtenerTodos()
    {
        throw new NotImplementedException();
    }

    // Implementación de los métodos de IGenericRepository
}

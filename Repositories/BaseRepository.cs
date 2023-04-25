using System.Linq.Expressions;
using server_dotnet_fitnessapp.Context;
using server_dotnet_fitnessapp.Repositories.Interfaces;

namespace server_dotnet_fitnessapp.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
{
    private readonly ApplicationDbContext _context;
    protected BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TEntity> Get()
    {
        return _context.Set<TEntity>();
    }

    public TEntity? GetById(object id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
    {
        return _context.Set<TEntity>().Where(filter);
    }

    public TEntity Insert(TEntity entity)
    {
        var createdEntity = _context.Set<TEntity>().Add(entity).Entity;
        _context.SaveChanges();
        return createdEntity;
    }

    public void InsertAll(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void DeleteById(object id)
    {
        TEntity? entity = GetById(id);
        if (entity != null) _context.Set<TEntity>().Remove(entity);
    }

    public TEntity Update(TEntity entity)
    {
        TEntity updatedEntity = _context.Set<TEntity>().Update(entity).Entity;
        _context.SaveChanges();
        return updatedEntity;
    }

    public void UpdateAll(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().UpdateRange(entities);
        _context.SaveChanges();
    }
}
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
{
    private readonly IBaseRepository<TEntity> _repository;

    public BaseService(IBaseRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public IEnumerable<TEntity> Get()
    {
        try
        {
            return _repository.Get();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public TEntity? GetById(object id)
    {
        try
        {
            return _repository.GetById(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;      
        }
    }
    
    public TEntity Insert(TEntity entity)
    {
        try
        {
            return _repository.Insert(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void InsertAll(IEnumerable<TEntity> entities)
    {
        try
        {
            _repository.InsertAll(entities);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Delete(TEntity entity)
    {
        try
        {
            _repository.Delete(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteById(object id)
    {
        try
        {
            _repository.DeleteById(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public TEntity Update(TEntity entity)
    {
        try
        {
            return _repository.Update(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateAll(IEnumerable<TEntity> entities)
    {
        try
        {
            _repository.UpdateAll(entities);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
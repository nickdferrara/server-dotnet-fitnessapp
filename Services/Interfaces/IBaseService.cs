using System.Linq.Expressions;

namespace server_dotnet_fitnessapp.Services.Interfaces;

public interface IBaseService<TEntity> where TEntity : class
{    
    IEnumerable<TEntity> Get();
    
    TEntity? GetById(object id);

    TEntity Insert(TEntity entity);

    void InsertAll(IEnumerable<TEntity> entities);
    
    void Delete(TEntity entity);

    void DeleteById(object id);

    TEntity Update(TEntity entity);

    void UpdateAll(IEnumerable<TEntity> entities);
    
}
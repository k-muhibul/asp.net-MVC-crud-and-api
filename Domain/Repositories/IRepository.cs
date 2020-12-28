using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(string includeProperties = "");
        TEntity GetById(object id);
        void Insert(TEntity entity);
      
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
        
        
    }
}

using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public interface IBaseRepository<TEntity>
        where TEntity : class,IEntity
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, params string[] include);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);  
    }
}

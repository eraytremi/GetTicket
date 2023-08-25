using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.EF
{
    public class BaseRepositoryEf<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var delete = context.Entry(entity);
                delete.State = EntityState.Deleted;
                await  context.SaveChangesAsync();
            }
        }

        public  async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            using (var context = new TContext())
            {

                IQueryable<TEntity> dbSet = context.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }
                
                return await dbSet.SingleOrDefaultAsync(predicate);
            }
        }

        

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, params string[] include)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> dbset = context.Set<TEntity>();
                if (include.Length > 0)
                {
                    foreach (var item in include)
                    {
                        dbset = dbset.Include(item);
                    }
                }
                if (expression == null)
                {
                    var list = dbset.ToList();
                    return list;
                }

                return await dbset.Where(expression).ToListAsync();
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var add = context.Entry(entity);
                add.State = EntityState.Added;
                await context.SaveChangesAsync();
                return  add.Entity;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var update = context.Entry(entity);
                update.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return update.Entity;
            }
        }
    }
}

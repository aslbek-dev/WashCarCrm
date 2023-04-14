using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashCarCrm.Infrastructure.Repositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);
        IQueryable<TEntity> SelectAll();
        ValueTask<TEntity> SelectByIdAsync(TKey id);
        ValueTask<TEntity> UpdateAsync(TEntity entity);
        ValueTask<TEntity> DeleteAsync(TEntity entity);
    }
}
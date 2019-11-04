using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> CatchAll();
        Task<TEntity> PickUpById(int id);
        Task<TEntity> PickUpById(string id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task Delete(string id);
    }
}

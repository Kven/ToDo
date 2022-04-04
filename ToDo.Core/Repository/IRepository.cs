using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToDo.Core.Repository
{
    public interface IRepository
    {
        Task<IQueryable<T>> GetAsync<T>() where T : IEntity;
        Task<IQueryable<T>> FindAsync<T>(Expression<Func<T, bool>> condition) where T : IEntity;
        Task CreateAsync<T>(T item) where T : IEntity;
        Task CreateManyAsync<T>(T[] items) where T : IEntity;
        Task UpdateAsync<T>(string id, T item) where T : IEntity;
        Task DeleteAsync<T>(string id) where T : IEntity;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ToDo.Core;
using ToDo.Core.Repository;

namespace ToDo.Repositorys.Mongo
{
    public class MongoRepository : IRepository
    {
        public Task CreateAsync<T>(T item) where T : IEntity
        {
            throw new NotImplementedException();
        }

        public Task CreateManyAsync<T>(T[] items) where T : IEntity
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(string id) where T : IEntity
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> FindAsync<T>(Expression<Func<T, bool>> condition) where T : IEntity
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAsync<T>() where T : IEntity
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(string id, T item) where T : IEntity
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Core;
using ToDo.Core.Options;
using ToDo.Core.Repository;

namespace ToDo.Repositorys.Mongo
{
    /// <summary>
    /// Репозиторий для работы с MongoDb
    /// </summary>
    public class MongoRepository : IRepository
    {
        private readonly IMongoDatabase _database;
        public MongoRepository(IOptions<DatabaseOptions> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DataBaseName);
        }

        public async Task CreateAsync<T>(T item) where T : IEntity
        {
            await GetCollection<T>().InsertOneAsync(item);
        }

        public async Task CreateManyAsync<T>(T[] items) where T : IEntity
        {
            await GetCollection<T>().InsertManyAsync(items);
        }

        public async Task DeleteAsync<T>(string id) where T : IEntity
        {
            await GetCollection<T>().DeleteOneAsync(s => s.Id == id);
        }

        public Task<IQueryable<T>> FindAsync<T>(Expression<Func<T, bool>> condition) where T : IEntity
        {
            return Task.FromResult(GetCollection<T>().AsQueryable().Where(condition));
        }

        public Task<IQueryable<T>> GetAsync<T>() where T : IEntity
        {
            return Task.FromResult<IQueryable<T>>(GetCollection<T>().AsQueryable());
        }

        public async Task UpdateAsync<T>(string id, T item) where T : IEntity
        {
            await GetCollection<T>().ReplaceOneAsync(s => s.Id == id, item, new ReplaceOptions { IsUpsert = true });
        }

        /// <summary>
        /// Получение коллекции по типу объекта
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемого объекта</typeparam>
        /// <returns>Типизированная коллекция</returns>
        private IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>(typeof(T).Name);
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToDo.Core.Repository
{
    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Получение фильтруемого набора записей
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемого объекта</typeparam>
        /// <returns>Набор данных с фильтрацией</returns>
        Task<IQueryable<T>> GetAsync<T>() where T : IEntity;

        /// <summary>
        /// Поиск записей по условию
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемого объекта</typeparam>
        /// <param name="condition">Условия</param>
        /// <returns>Набор данных с фильтрацией</returns>
        Task<IQueryable<T>> FindAsync<T>(Expression<Func<T, bool>> condition) where T : IEntity;

        /// <summary>
        /// Добавление новой записи в базу данных
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемого объекта</typeparam>
        /// <param name="item">Добавляемый объект</param>
        /// <returns>Добавленный объект</returns>
        Task CreateAsync<T>(T item) where T : IEntity;

        /// <summary>
        /// Добавление массива новых записей в базу данных
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемого объекта</typeparam>
        /// <param name="items">Массив добавляемых объектов</param>
        /// <returns>Массив идентификаторов добавленных в базу данных</returns>
        Task CreateManyAsync<T>(T[] items) where T : IEntity;

        /// <summary>
        /// Обновление записи
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемого объекта</typeparam>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="item">Обновленный объект</param>
        /// <returns>Результат обновления</returns>
        Task UpdateAsync<T>(string id, T item) where T : IEntity;

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемого объекта</typeparam>
        /// <param name="id"><Идентификатор объекта/param>
        /// <returns>Результат обновления</returns>
        Task DeleteAsync<T>(string id) where T : IEntity;
    }
}

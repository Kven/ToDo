using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace ToDo.Core.Entitys
{
    /// <summary>
    /// Модель todo
    /// </summary>
    public class ItemEntity : IEntity
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; init; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Статус выполнения
        /// </summary>
        public bool Complited { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; init; } = DateTime.Now;

        public ItemEntity()
        {

        }
        public ItemEntity(string title)
        {
            Title = title;
        }
        
    }
}

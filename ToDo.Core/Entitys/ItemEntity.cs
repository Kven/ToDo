using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace ToDo.Core.Entitys
{
    public class ItemEntity : IEntity
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; init; }
        public string Title { get; set; }
        public bool Complited { get; set; }
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

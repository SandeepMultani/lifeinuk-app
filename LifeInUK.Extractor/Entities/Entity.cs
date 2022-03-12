using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LifeInUK.Extractor.Entities
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
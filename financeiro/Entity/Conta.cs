using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Contas.Entity
{
    public class Conta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }
}

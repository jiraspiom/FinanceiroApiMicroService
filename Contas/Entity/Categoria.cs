using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Contas.Entity
{
    public class Categoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("tipo")]
        public string Tipo { get; set; }

        [BsonElement("status")]
        public bool Status { get; set; }

        [BsonElement("created_at")]
        public DateTime Created_at { get; set; } = DateTime.Now;

        [BsonElement("updated_at")]
        public DateTime? Updated_at { get; set; }
    }
}

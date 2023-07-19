using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Contas.Entity
{
    public class Cor
    {
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Contas.Entity
{
    public class Instituicao
    {
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("created_at")]
        public DateTime Created_at { get; set; } = DateTime.Now;

        [BsonElement("updated_at")]
        public DateTime? Updated_at { get; set; }
    }
}

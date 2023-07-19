using MongoDB.Bson.Serialization.Attributes;

namespace Contas.Entity
{
    public class Categoria
    {
        [BsonElement("id")]
        public int Id { get; set; }

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

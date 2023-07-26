using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Transacoes.Entity
{
    public class Conta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("saldo")]
        public double Saldo { get; set; }

        [BsonElement("ativo")]
        public bool Ativo { get; set; }

        [BsonElement("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pagamentos.Entity
{
    public class Transferencia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("valor")]
        public double Valor { get; set; }

        [BsonElement("data")]
        public DateTime Data { get; set; }

        [BsonElement("conta_origem_id")]
        public string ContaOrigemId { get; set; }

        [BsonElement("conta_destino_id")]
        public string ContaDestinoId { get; set; }

        [BsonElement("tag")]
        public string Tag { get; set; } 

        [BsonElement("observacao")]
        public string Observacao { get; set; }

        [BsonElement("tranferencia_fixa")]
        public bool TranferenciaFixa { get; set; } = false;

        // Datas
        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

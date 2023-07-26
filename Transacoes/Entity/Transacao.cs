using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Transacoes.Entity
{
    public class Transacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("valor")]
        public double Valor { get; set; }

        [BsonElement("data")]
        public DateTime Data { get; set; }

        [BsonElement("status")]
        public enumStatus StatusId { get; set; }

        [BsonElement("descricao")]
        public string Descricao { get; set; }

        [BsonElement("categoria_id")]
        public string CategoriaId { get; set; }

        [BsonElement("conta_id")]
        public string ContaId { get; set; }

        // mais detalhes
        [BsonElement("tag")]
        public string? Tag { get; set; }

        [BsonElement("observacao")]
        public string? Observacao { get; set; }

        [BsonElement("fixa")]
        public bool Fixa { get; set; } = false;

        [BsonElement("repetir")]
        public bool Repetir { get; set; } = false;

        [BsonElement("lembrete")]
        public DateTime? Lembrete { get; set; }

        // Datas
        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

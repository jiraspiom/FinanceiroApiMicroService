using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pagamentos.Entity
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

        [BsonElement("descricao")]
        public string Descricao { get; set; }

        [BsonElement("status")]
        public Status StatusId { get; set; }

        [BsonElement("beneficiario_id")]
        public string BeneficiarioId { get; set; }

        [BsonElement("categoria_id")]
        public string CategoriaId { get; set; }

        [BsonElement("sub_categoria_id")]
        public string SubCategoriaId { get; set; }

        [BsonElement("conta_id")]
        public string ContaId { get; set; }

        [BsonElement("anexo")]
        public  string Anexo { get; set; }

        [BsonElement("fixa")]
        public bool Fixa { get; set; } = false;

        [BsonElement("repetir")]
        public bool Repetir { get; set; } = false;

        [BsonElement("observacao")]
        public string Observacao { get; set; }

        [BsonElement("tab")]
        public string Tag { get; set; }

        [BsonElement("lembrete")]
        public DateTime Lembrete { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}

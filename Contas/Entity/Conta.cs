using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Contas.Entity
{
    /// <summary>
    /// Representa Contas
    /// </summary>
    public class Conta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("saldo")]
        public double Saldo { get; set; }

        [BsonElement("incluir_soma")]
        public bool IncluirSoma { get; set; }

        [BsonElement("ativo")]
        public bool Ativo { get; set; }

        [BsonElement("instituicao_id")]
        public string InstituicaoId { get; set; }

        [BsonElement("conta_tipo_id")]
        public string ContaTipoId { get; set; }

        [BsonElement("cor")]
        public enumCor Cor { get; set; }

        [BsonElement("created_at")]
        public DateTime Created_at { get; set; } = DateTime.Now;

        [BsonElement("updated_at")]
        public DateTime? Updated_at { get; set; }
    }
}


/*
 Statu descricao: 'Pendente')
Statu descricao: 'Efetuada')
Statu. (descricao: 'Nula')
Statu.find_or_create_by!(descricao: 'Acompanhar')
Statu.find_or_create_by!(descricao: 'Duplicar')
 */
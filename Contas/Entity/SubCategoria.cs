using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Contas.Entity
{
    public class SubCategoria : Categoria
    {
        [BsonElement("catetorida_id")]
        public string CategoriaId { get; set; }
    }
}

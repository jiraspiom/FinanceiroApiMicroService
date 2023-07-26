using MongoDB.Driver;

namespace Transacoes.DataBase
{
    public interface IMongoContexto
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}

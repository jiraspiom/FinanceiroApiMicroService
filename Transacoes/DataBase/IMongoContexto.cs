using MongoDB.Driver;

namespace Pagamentos.DataBase
{
    public interface IMongoContexto
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}

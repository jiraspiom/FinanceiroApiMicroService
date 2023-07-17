using Contas.Entity;
using MongoDB.Driver;

namespace financeiro.DataBase
{
    public interface IMongoContext
    {
        IMongoCollection<Conta> Contas { get; }
    }
}

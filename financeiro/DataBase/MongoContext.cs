using Contas.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace financeiro.DataBase
{
    public class MongoContext : IMongoContext
    {
       private readonly IMongoDatabase _database;
        public MongoContext(IOptions<MongoDBSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.DataBaseName);
        }

        public IMongoCollection<Conta> Contas => _database.GetCollection<Conta>("contas");

    }
}

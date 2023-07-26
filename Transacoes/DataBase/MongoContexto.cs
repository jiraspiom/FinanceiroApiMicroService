using financeiro.DataBase;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Transacoes.DataBase
{
    public class MongoContexto : IMongoContexto
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public MongoContexto(IOptions<MongoDBSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DataBaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}

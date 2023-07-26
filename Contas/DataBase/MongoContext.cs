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

        public IMongoCollection<Conta> Contas => _database.GetCollection<Conta>("conta");

        public IMongoCollection<Instituicao> Instituicoes => _database.GetCollection<Instituicao>("instituicao");

        public IMongoCollection<ContaTipo> ContaTipos => _database.GetCollection<ContaTipo>("contatipo");

        public IMongoCollection<Categoria> Categorias => _database.GetCollection<Categoria>("catetoria");

    }
}

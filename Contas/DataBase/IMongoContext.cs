using Contas.Entity;
using MongoDB.Driver;

namespace financeiro.DataBase
{
    public interface IMongoContext
    {
        IMongoCollection<Conta> Contas { get; }
        IMongoCollection<Instituicao> Instituicoes { get; }

        IMongoCollection<ContaTipo> ContaTipos { get; }

        IMongoCollection<Categoria> Categorias { get; }
    }
}

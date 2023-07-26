using MongoDB.Driver;
using Transacoes.DataBase;
using Transacoes.Entity;
using Transacoes.Interface;

namespace Transacoes.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly IMongoContexto _contexto;
        protected IMongoCollection<Conta> _dbCollection;
        public ContaRepository(IMongoContexto context)
        {
            _contexto = context;
            _dbCollection = _contexto.GetCollection<Conta>(typeof(Conta).Name.ToLower());
        }

        public async Task<Conta> GetbyId(string id)
        {
            return await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(string id, Conta model)
        {
            await _dbCollection.ReplaceOneAsync(u => u.Id == id, model);
        }
    }
}

using MongoDB.Driver;
using Transacoes.DataBase;
using Transacoes.Entity;
using Transacoes.Interface.Repository;

namespace Transacoes.Repository
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly IMongoContexto _contexto;
        protected IMongoCollection<Despesa> _dbCollection;
        public DespesaRepository(IMongoContexto context)
        {
            _contexto = context;
            _dbCollection = _contexto.GetCollection<Despesa>(typeof(Despesa).Name);
        }

        public async Task<IList<Despesa>> GetAll()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Despesa> GetbyId(string id)
        {
            return await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Despesa model)
        {
            await _dbCollection.InsertOneAsync(model);
        }

        public async Task Delete(string id)
        {
            await _dbCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task Update(string id, Despesa model)
        {
            await _dbCollection.ReplaceOneAsync(u => u.Id == id, model);
        }
    }
}

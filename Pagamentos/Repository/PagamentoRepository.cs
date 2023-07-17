using MongoDB.Driver;
using Pagamentos.DataBase;
using Pagamentos.Entity;
using Pagamentos.Interface;

namespace Pagamentos.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly IMongoContexto _contexto;
        protected IMongoCollection<Pagamento> _dbCollection;
        public PagamentoRepository(IMongoContexto context)
        {
            _contexto = context;
            _dbCollection = _contexto.GetCollection<Pagamento>(typeof(Pagamento).Name);
        }

        public async Task<IList<Pagamento>> GetAll()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Pagamento> GetbyId(string id)
        {
            return await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Pagamento pagamento)
        {
            await _dbCollection.InsertOneAsync(pagamento);
        }

        public async Task Delete(string id)
        {
            await _dbCollection.DeleteOneAsync(id);
        }

        public async Task Update(string id, Pagamento pagamento)
        {
            await _dbCollection.ReplaceOneAsync(id, pagamento);
        }
    }
}

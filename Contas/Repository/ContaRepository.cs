using Contas.Entity;
using financeiro.DataBase;
using financeiro.Interface;
using MongoDB.Driver;

namespace financeiro.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly IMongoContext _context;
        public ContaRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<IList<Conta>> GetAll()
        {
            return await _context
                .Contas
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<Conta> GetbyId(string id)
        {
            return await _context
                .Contas
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Add(Conta conta)
        {
            await _context.Contas.InsertOneAsync(conta);
        }

        public async Task Delete(string id)
        {
            await _context.Contas.DeleteOneAsync(x => x.Id == id);
        }

        public async Task Update(string id, Conta conta)
        {
            await _context.Contas.ReplaceOneAsync(u => u.Id == id, conta);
        }
    }
}

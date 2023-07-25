﻿using MongoDB.Driver;
using Pagamentos.DataBase;
using Pagamentos.Entity;
using Pagamentos.Interface;

namespace Pagamentos.Repository
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly IMongoContexto _contexto;
        protected IMongoCollection<Transferencia> _dbCollection;
        public TransferenciaRepository(IMongoContexto context)
        {
            _contexto = context;
            _dbCollection = _contexto.GetCollection<Transferencia>(typeof(Transferencia).Name);
        }

        public async Task<IList<Transferencia>> GetAll()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Transferencia> GetbyId(string id)
        {
            return await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Transferencia model)
        {
            await _dbCollection.InsertOneAsync(model);
        }

        public async Task Delete(string id)
        {
            await _dbCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task Update(string id, Transferencia model)
        {
            await _dbCollection.ReplaceOneAsync(u => u.Id == id, model);
        }
    }
}
﻿using MongoDB.Driver;
using Transacoes.DataBase;
using Transacoes.Entity;
using Transacoes.Interface.Repository;

namespace Transacoes.Repository
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly IMongoContexto _contexto;
        protected IMongoCollection<Receita> _dbCollection;
        public ReceitaRepository(IMongoContexto context)
        {
            _contexto = context;
            _dbCollection = _contexto.GetCollection<Receita>(typeof(Receita).Name.ToLower());
        }

        public async Task<IList<Receita>> GetAll()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Receita> GetbyId(string id)
        {
            return await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Receita model)
        {
            await _dbCollection.InsertOneAsync(model);
        }

        public async Task Delete(string id)
        {
            await _dbCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task Update(string id, Receita model)
        {
            await _dbCollection.ReplaceOneAsync(u => u.Id == id, model);
        }

        public async Task<TransacaoTotal> GetTotal()
        {
            var pendente =  _dbCollection.AsQueryable()
                .Where(x => x.StatusId != enumStatus.Efetuada)
                .Sum(x => x.Valor);

            var efetuada = _dbCollection.AsQueryable()
                .Where(x => x.StatusId.Equals(enumStatus.Efetuada))
                .Sum(x => x.Valor);

            var total = _dbCollection.AsQueryable()
                .Where(_ => true)
                .Sum(x => x.Valor);

            return new TransacaoTotal { Total = total, Pendente = pendente, Efetuada = efetuada };
        }
    }
}

using Transacoes.Entity;
using Transacoes.Interface;
using Transacoes.Interface.Repository;

namespace Transacoes.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;
        public ContaService(IContaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Conta> GetByIdContaAsync(string id)
        {
            try
            {
                var conta = await _repository.GetbyId(id);
                if (conta == null) return null;

                return conta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateConta(string id, Conta model)
        {
            if (await _repository.GetbyId(id) != null)
            {
                model.UpdatedAt = DateTime.Now;
                await _repository.Update(id, model);
            }
        }
    }
}

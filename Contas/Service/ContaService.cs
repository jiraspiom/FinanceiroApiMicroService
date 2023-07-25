using Contas.Entity;
using Contas.Interface;
using financeiro.Interface;

namespace Contas.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;
        public ContaService(IContaRepository contaService)
        {
            _repository = contaService;
        }

        public async Task<IList<Conta>> GetAllContaAsync()
        {
            try
            {
                var contas = await _repository.GetAll();
                if (contas == null) return null;

                return contas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public async Task<Conta> AddConta(Conta conta)
        {
            if (await _repository.GetbyId(conta.Id) == null)
            {
                await _repository.Add(conta);
                return conta;
            }
            return null;
        }

        public async Task DeleteConta(string id)
        {
            var conta = await _repository.GetbyId(id);
            if (conta == null)
                throw new Exception("conta não existe");
            await _repository.Delete(id);
        }

        public async Task UpdateConta(string id, Conta conta)
        {
            if (await _repository.GetbyId(id) != null)
            {
                conta.Updated_at = DateTime.Now;
                await _repository.Update(id, conta);
            }
        }
    }
}

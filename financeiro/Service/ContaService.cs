using Contas.Entity;
using Contas.Interface;
using financeiro.Interface;

namespace Contas.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaService;
        public ContaService(IContaRepository contaService)
        {
            _contaService = contaService;
        }

        public async Task<IList<Conta>> GetAllContaAsync()
        {
            try
            {
                var contas = await _contaService.GetAll();
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
                var conta = await _contaService.GetbyId(id);
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
            if (await _contaService.GetbyId(conta.Id) == null)
            {
                await _contaService.Add(conta);
                return conta;
            }
            return null;
        }

        public async Task DeleteConta(string id)
        {
            var conta = await _contaService.GetbyId(id);
            if (conta == null)
                throw new Exception("conta no existe");
            await _contaService.Delete(id);
        }

        public async Task UpdateConta(string id, Conta conta)
        {
            if (await _contaService.GetbyId(id) != null)
            {
                await _contaService.Update(id, conta);
            }
        }
    }
}

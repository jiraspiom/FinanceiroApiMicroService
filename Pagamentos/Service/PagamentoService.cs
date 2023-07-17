using Pagamentos.Entity;
using Pagamentos.Interface;

namespace Pagamentos.Service
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _repository;
        public PagamentoService(IPagamentoRepository repository)
        {
            _repository = repository;   
        }
        public async Task<IList<Pagamento>> GetAllPagamentoAsync()
        {
            try
            {
                var pagamentos = await _repository.GetAll();
                if (pagamentos == null) return null;

                return pagamentos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pagamento> GetByIdPagamentoAsync(string id)
        {
            try
            {
                var pagamento = await _repository.GetbyId(id);
                if (pagamento == null) return null;

                return pagamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pagamento> AddPagamento(Pagamento pagamento)
        {
            if (await _repository.GetbyId(pagamento.Id) == null)
            {
                await _repository.Add(pagamento);
                return pagamento;
            }
            return null;
        }

        public async Task DeletePagamento(string id)
        {
            var pagamento = await _repository.GetbyId(id);
            if (pagamento == null)
                throw new Exception("pagamento no existe");
            await _repository.Delete(id);
        }

        public async Task UpdatePagamento(string id, Pagamento pagamento)
        {
            if (await _repository.GetbyId(id) != null)
            {
                await _repository.Update(id, pagamento);
            }
        }
    }
}

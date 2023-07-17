using Pagamentos.Entity;

namespace Pagamentos.Interface
{
    public interface IPagamentoService
    {
        Task<IList<Pagamento>> GetAllPagamentoAsync();
        Task<Pagamento> GetByIdPagamentoAsync(string id);
        Task<Pagamento> AddPagamento(Pagamento pagamento);
        Task DeletePagamento(string id);
        Task UpdatePagamento(string id, Pagamento pagamento);
    }
}

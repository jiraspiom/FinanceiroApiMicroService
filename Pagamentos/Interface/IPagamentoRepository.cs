using Pagamentos.Entity;

namespace Pagamentos.Interface
{
    public interface IPagamentoRepository
    {
        Task<IList<Pagamento>> GetAll();
        Task<Pagamento> GetbyId(string id);
        Task Add(Pagamento pagamento);
        Task Delete(string id);
        Task Update(string id, Pagamento pagamento);
    }
}

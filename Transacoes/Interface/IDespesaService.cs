using Pagamentos.Entity;

namespace Pagamentos.Interface
{
    public interface IDespesaService
    {
        Task<IList<Despesa>> GetAllDespesaAsync();
        Task<Despesa> GetByIdDespesaAsync(string id);
        Task<Despesa> AddDespesa(Despesa model);
        Task DeleteDespesa(string id);
        Task UpdateDespesa(string id, Despesa model);
    }
}

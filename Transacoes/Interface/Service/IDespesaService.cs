using Transacoes.Entity;

namespace Transacoes.Interface.Service
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

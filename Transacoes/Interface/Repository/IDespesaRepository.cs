using Transacoes.Entity;

namespace Transacoes.Interface.Repository
{
    public interface IDespesaRepository
    {
        Task<IList<Despesa>> GetAll();
        Task<Despesa> GetbyId(string id);
        Task Add(Despesa model);
        Task Delete(string id);
        Task Update(string id, Despesa model);

        Task<TransacaoTotal> GetTotal();
    }
}

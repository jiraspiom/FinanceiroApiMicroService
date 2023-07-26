using Transacoes.Entity;

namespace Transacoes.Interface.Repository
{
    public interface IReceitaRepository
    {
        Task<IList<Receita>> GetAll();
        Task<Receita> GetbyId(string id);
        Task Add(Receita model);
        Task Delete(string id);
        Task Update(string id, Receita model);
    }
}

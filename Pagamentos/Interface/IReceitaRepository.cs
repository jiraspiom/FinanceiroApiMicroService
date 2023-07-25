using Pagamentos.Entity;

namespace Pagamentos.Interface
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

using Contas.Entity;

namespace financeiro.Interface
{
    public interface IContaRepository
    {
        Task<IList<Conta>> GetAll();
        Task<Conta> GetbyId(string id);
        Task Add(Conta conta);
        Task Delete(string id);
        Task Update(string id, Conta conta);
    }
}

using Transacoes.Entity;

namespace Transacoes.Interface
{
    public interface IContaRepository
    {
        Task<Conta> GetbyId(string id);
        Task Update(string id, Conta model);
    }
}

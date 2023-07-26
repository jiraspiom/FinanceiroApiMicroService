using Transacoes.Entity;

namespace Transacoes.Interface
{
    public interface IContaService
    {
        Task<Conta> GetByIdContaAsync(string id);
        Task UpdateConta(string id, Conta model);
    }
}

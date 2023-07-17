using Contas.Entity;

namespace Contas.Interface
{
    public interface IContaService
    {
        Task<IList<Conta>> GetAllContaAsync();
        Task<Conta> GetByIdContaAsync(string id);
        Task<Conta> AddConta(Conta conta);
        Task DeleteConta(string id);
        Task UpdateConta(string id, Conta conta);
    }
}

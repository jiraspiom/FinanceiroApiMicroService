using Transacoes.Entity;

namespace Transacoes.Interface.Service
{
    public interface ITransferenciaService
    {
        Task<IList<Transferencia>> GetAllTransferenciaAsync();
        Task<Transferencia> GetByIdTransferenciaAsync(string id);
        Task<Transferencia> AddTransferencia(Transferencia model);
        Task DeleteTransferencia(string id);
        Task UpdateTransferencia(string id, Transferencia model);
    }
}

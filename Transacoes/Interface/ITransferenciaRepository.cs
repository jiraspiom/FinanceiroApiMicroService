using Pagamentos.Entity;

namespace Pagamentos.Interface
{
    public interface ITransferenciaRepository
    {
        Task<IList<Transferencia>> GetAll();
        Task<Transferencia> GetbyId(string id);
        Task Add(Transferencia model);
        Task Delete(string id);
        Task Update(string id, Transferencia model);
    }
}

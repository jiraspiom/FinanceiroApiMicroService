using Transacoes.Entity;

namespace Transacoes.Interface.Service
{
    public interface IReceitaService
    {
        Task<IList<Receita>> GetAllReceitaAsync();
        Task<Receita> GetByIdReceitaAsync(string id);
        Task<Receita> AddReceita(Receita model);
        Task DeleteReceita(string id);
        Task UpdateReceita(string id, Receita model);

        Task<TransacaoTotal> GetTotalReceita();
    }
}

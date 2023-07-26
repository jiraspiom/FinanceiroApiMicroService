using Transacoes.Entity;

namespace Transacoes.Interface
{
    public interface IContaService
    {
        Task<Conta> GetByIdContaAsync(string id);
        Task UpdateConta(string id, Conta model);
    }
}


// inicio atualizar conta
//var origem = await _contaService.GetByIdContaAsync(model.ContaOrigemId);
//var destino = await _contaService.GetByIdContaAsync(model.ContaDestinoId);
//origem.Saldo -= model.Valor;
//origem.UpdatedAt = DateTime.Now;
//destino.Saldo += model.Valor;
//destino.UpdatedAt = DateTime.Now;
//await _contaService.UpdateConta(origem.Id, origem);
//await _contaService.UpdateConta(destino.Id, destino);
// fin atualizar conta
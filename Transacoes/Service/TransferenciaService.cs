using Transacoes.Entity;
using Transacoes.Interface;
using Transacoes.Interface.Repository;
using Transacoes.Interface.Service;

namespace Transacoes.Service
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ITransferenciaRepository _repository;

        private readonly IContaService _contaService;

        public TransferenciaService(
            ITransferenciaRepository repository,
            IContaService contaService
            )
        {
            _repository = repository;
            _contaService = contaService;
        }
        public async Task<IList<Transferencia>> GetAllTransferenciaAsync()
        {
            try
            {
                var Transferencias = await _repository.GetAll();
                if (Transferencias == null) return null;

                return Transferencias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Transferencia> GetByIdTransferenciaAsync(string id)
        {
            try
            {
                var Transferencia = await _repository.GetbyId(id);
                if (Transferencia == null) return null;

                return Transferencia;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Transferencia> AddTransferencia(Transferencia model)
        {
            try
            {
                if (await _repository.GetbyId(model.Id) == null)
                {
                    // inicio atualizar conta
                    var origem = await _contaService.GetByIdContaAsync(model.ContaOrigemId);
                    var destino = await _contaService.GetByIdContaAsync(model.ContaDestinoId);
                    origem.Saldo -= model.Valor;
                    origem.UpdatedAt = DateTime.Now;
                    destino.Saldo += model.Valor;
                    destino.UpdatedAt = DateTime.Now;
                    await _contaService.UpdateConta(origem.Id, origem);
                    await _contaService.UpdateConta(destino.Id, destino);
                    // fin atualizar conta

                    await _repository.Add(model);
                    return model;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteTransferencia(string id)
        {
            var Transferencia = await _repository.GetbyId(id);
            if (Transferencia == null)
                throw new Exception("Transferencia não existe");
            await _repository.Delete(id);
        }

        public async Task UpdateTransferencia(string id, Transferencia model)
        {
            if (await _repository.GetbyId(id) != null)
            {
                model.UpdatedAt = DateTime.Now;
                await _repository.Update(id, model);
            }
        }
    }
}

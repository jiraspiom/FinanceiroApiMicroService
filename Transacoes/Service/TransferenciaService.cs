using Transacoes.Entity;
using Transacoes.Interface.Repository;
using Transacoes.Interface.Service;

namespace Transacoes.Service
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ITransferenciaRepository _repository;

        private readonly IDespesaRepository _despesaRepository;
        private readonly IReceitaRepository _receitaRepository;

        public TransferenciaService(
            ITransferenciaRepository repository, 
            IDespesaRepository despesaRepository, 
            IReceitaRepository receitaRepository
            )
        {
            _repository = repository;
            _despesaRepository = despesaRepository;
            _receitaRepository = receitaRepository;
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
            if (await _repository.GetbyId(model.Id) == null)
            {
                await _repository.Add(model);
                return model;
            }
            return null;
        }

        public async Task DeleteTransferencia(string id)
        {
            var Transferencia = await _repository.GetbyId(id);
            if (Transferencia == null)
                throw new Exception("Transferencia não existe");
            await _repository.Delete(id);
        }

        public async Task UpdateTransferencia(string id, Transferencia Transferencia)
        {
            if (await _repository.GetbyId(id) != null)
            {
                Transferencia.UpdatedAt = DateTime.Now;
                await _repository.Update(id, Transferencia);
            }
        }
    }
}

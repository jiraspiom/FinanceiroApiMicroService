using Transacoes.Entity;
using Transacoes.Interface.Repository;
using Transacoes.Interface.Service;

namespace Transacoes.Service
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _repository;
        public DespesaService(IDespesaRepository repository)
        {
            _repository = repository;   
        }
        public async Task<IList<Despesa>> GetAllDespesaAsync()
        {
            try
            {
                var despesas = await _repository.GetAll();
                if (despesas == null) return null;

                return despesas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Despesa> GetByIdDespesaAsync(string id)
        {
            try
            {
                var despesa = await _repository.GetbyId(id);
                if (despesa == null) return null;

                return despesa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Despesa> AddDespesa(Despesa model)
        {
            if (await _repository.GetbyId(model.Id) == null)
            {
                await _repository.Add(model);
                return model;
            }
            return null;
        }

        public async Task DeleteDespesa(string id)
        {
            var despesa = await _repository.GetbyId(id);
            if (despesa == null)
                throw new Exception("despesa não existe");
            await _repository.Delete(id);
        }

        public async Task UpdateDespesa(string id, Despesa despesa)
        {
            if (await _repository.GetbyId(id) != null)
            {
                despesa.UpdatedAt = DateTime.Now;
                await _repository.Update(id, despesa);
            }
        }
    }
}

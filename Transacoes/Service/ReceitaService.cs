using Pagamentos.Entity;
using Pagamentos.Interface;

namespace Pagamentos.Service
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _repository;
        public ReceitaService(IReceitaRepository repository)
        {
            _repository = repository;   
        }
        public async Task<IList<Receita>> GetAllReceitaAsync()
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

        public async Task<Receita> GetByIdReceitaAsync(string id)
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

        public async Task<Receita> AddReceita(Receita model)
        {
            if (await _repository.GetbyId(model.Id) == null)
            {
                await _repository.Add(model);
                return model;
            }
            return null;
        }

        public async Task DeleteReceita(string id)
        {
            var despesa = await _repository.GetbyId(id);
            if (despesa == null)
                throw new Exception("despesa no existe");
            await _repository.Delete(id);
        }

        public async Task UpdateReceita(string id, Receita despesa)
        {
            if (await _repository.GetbyId(id) != null)
            {
                await _repository.Update(id, despesa);
            }
        }
    }
}

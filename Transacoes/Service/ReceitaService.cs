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
                var receitas = await _repository.GetAll();
                if (receitas == null) return null;

                return receitas;
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
                var receita = await _repository.GetbyId(id);
                if (receita == null) return null;

                return receita;
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
            var receita = await _repository.GetbyId(id);
            if (receita == null)
                throw new Exception("receita não existe");
            await _repository.Delete(id);
        }

        public async Task UpdateReceita(string id, Receita receita)
        {
            if (await _repository.GetbyId(id) != null)
            {
                receita.UpdatedAt = DateTime.Now;
                await _repository.Update(id, receita);
            }
        }
    }
}

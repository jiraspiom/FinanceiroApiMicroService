namespace financeiro.Interface
{
    public interface IGeralRepository
    {
        void Adicionar<T>(T entity) where T : class;
        void Atualizar<T>(T entinty) where T : class;
        void Deletar<T>(T entinty) where T : class;

        Task<bool> SalvarMudancasAsync();
    }
}

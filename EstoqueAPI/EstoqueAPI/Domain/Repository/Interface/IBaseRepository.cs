namespace EstoqueAPI.Domain.Repository.Interface
{
    public interface IBaseRepository<T, Id> where T : class
    {
        Task<IEnumerable<T>> Obter();
        Task<T> ObterPorId(Id id);
        Task<T> Criar(T entidade);
        Task<T> Atualizar(T entidade);
        Task Deletar (T entidade);
    }
}

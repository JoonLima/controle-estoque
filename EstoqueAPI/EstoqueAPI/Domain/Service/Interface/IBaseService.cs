namespace EstoqueAPI.Domain.Service.Interface
{
    /// <summary>
    /// Interface genérica para criação de serviços do tipo CRUD
    /// </summary>
    /// <typeparam name="Request">Contrato de request</typeparam>
    /// <typeparam name="Response">Contrato de response</typeparam>
    /// <typeparam name="Id">Tipo do identificador</typeparam>
    public interface IBaseService <Request, Response, Id> where Request : class
    {
        Task <IEnumerable<Response>> Obter();
        Task <Response> ObterPorId(Id id);
        Task <Response> Criar(Request entidade);
        Task <Response> Atualizar(Id id, Request entidade);
        Task Deletar(Id id);

    }
}

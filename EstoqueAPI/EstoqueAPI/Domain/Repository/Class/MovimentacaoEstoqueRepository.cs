using EstoqueAPI.Domain.Models;
using EstoqueAPI.Domain.Repository.Interface;

namespace EstoqueAPI.Domain.Repository.Class
{
    public class MovimentacaoEstoqueRepository : IBaseRepository<MovimentacaoEstoque, int>
    {
        public Task<MovimentacaoEstoque> Atualizar(MovimentacaoEstoque entidade)
        {
            throw new NotImplementedException();
        }

        public Task<MovimentacaoEstoque> Criar(MovimentacaoEstoque entidade)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(MovimentacaoEstoque entidade)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovimentacaoEstoque>> Obter()
        {
            throw new NotImplementedException();
        }

        public Task<MovimentacaoEstoque> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

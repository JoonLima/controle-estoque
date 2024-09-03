using EstoqueAPI.Domain.Models;
using EstoqueAPI.Domain.Repository.Interface;

namespace EstoqueAPI.Domain.Repository.Class
{
    public class CategoriaRepository : IBaseRepository<Categoria, int>
    {
        public Task<Categoria> Atualizar(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> Criar(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> Obter()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

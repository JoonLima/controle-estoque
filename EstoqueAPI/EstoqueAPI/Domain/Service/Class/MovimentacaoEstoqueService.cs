using AutoMapper;
using EstoqueAPI.Contract.MovimentacaoEstoque;
using EstoqueAPI.Domain.Models;
using EstoqueAPI.Domain.Repository.Interface;
using EstoqueAPI.Domain.Service.Interface;

namespace EstoqueAPI.Domain.Service.Class
{
    public class MovimentacaoEstoqueService : IBaseService<MovimentacaoEstoqueRequestContract, MovimentacaoEstoqueResponseContract, int>
    {
        private readonly IBaseRepository<MovimentacaoEstoque, int> _repository;
        private readonly IMapper _mapper;
        public MovimentacaoEstoqueService(IBaseRepository<MovimentacaoEstoque, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<MovimentacaoEstoqueResponseContract> Atualizar(int id, MovimentacaoEstoqueRequestContract entidade)
        {
            var movimentacaoEstoqueExistente = await _repository.ObterPorId(id);
            if (movimentacaoEstoqueExistente == null) throw new Exception("Movimentação de estoque não encontrada.");

            var movimentacaoEstoqueAtualizada = _mapper.Map<MovimentacaoEstoque>(entidade);
            movimentacaoEstoqueAtualizada.Id = movimentacaoEstoqueExistente.Id;

            await _repository.Atualizar(movimentacaoEstoqueAtualizada);
            return _mapper.Map<MovimentacaoEstoqueResponseContract>(movimentacaoEstoqueAtualizada);
        }

        public async Task<MovimentacaoEstoqueResponseContract> Criar(MovimentacaoEstoqueRequestContract entidade)
        {
            var movimentacaoEstoque = _mapper.Map<MovimentacaoEstoque>(entidade);
            await _repository.Criar(movimentacaoEstoque);
            return _mapper.Map<MovimentacaoEstoqueResponseContract>(movimentacaoEstoque);
        }

        public async Task Deletar(int id)
        {
            var movimentacaoEstoque = await _repository.ObterPorId(id);
            if (movimentacaoEstoque == null) throw new Exception("Movimentação de estoque não encontrada.");
            await _repository.Deletar(movimentacaoEstoque);
        }

        public async Task<IEnumerable<MovimentacaoEstoqueResponseContract>> Obter()
        {
            var movimentacaoEstoque = await _repository.Obter();
            return _mapper.Map<IEnumerable<MovimentacaoEstoqueResponseContract>>(movimentacaoEstoque);
        }

        public async Task<MovimentacaoEstoqueResponseContract> ObterPorId(int id)
        {
            var movimentacaoEstoque = await _repository.ObterPorId(id);
            if (movimentacaoEstoque == null) throw new Exception("Movimentação de estoque não encontrada.");
            return _mapper.Map<MovimentacaoEstoqueResponseContract>(movimentacaoEstoque);
        }
    }
}

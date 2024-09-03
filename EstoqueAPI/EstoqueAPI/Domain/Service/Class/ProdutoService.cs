using AutoMapper;
using EstoqueAPI.Contract.Produto;
using EstoqueAPI.Domain.Models;
using EstoqueAPI.Domain.Repository.Interface;
using EstoqueAPI.Domain.Service.Interface;

namespace EstoqueAPI.Domain.Service.Class
{
    public class ProdutoService : IBaseService<ProdutoRequestContract, ProdutoResponseContract, int>
    {
        private readonly IBaseRepository<Produto, int> _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IBaseRepository<Produto, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProdutoResponseContract> Atualizar(int id, ProdutoRequestContract entidade)
        {
            var produtoExistente = await _repository.ObterPorId(id);

            if (produtoExistente == null) throw new Exception("Produto não encontrado.");

            var produtoAtualizado = _mapper.Map<Produto>(entidade);
            produtoAtualizado.Id = produtoExistente.Id;

            await _repository.Atualizar(produtoAtualizado);

            return _mapper.Map<ProdutoResponseContract>(produtoAtualizado);

        }

        public async Task<ProdutoResponseContract> Criar(ProdutoRequestContract entidade)
        {
            var produto = _mapper.Map<Produto>(entidade);
            await _repository.Criar(produto);
            return _mapper.Map<ProdutoResponseContract>(produto);
        }

        public async Task Deletar(int id)
        {
            var produto = await _repository.ObterPorId(id);
            if (produto == null) throw new Exception("Produto não encontrado.");
            await _repository.Deletar(produto);
        }

        public async Task<IEnumerable<ProdutoResponseContract>> Obter()
        {
            var produtos = await _repository.Obter();
            return _mapper.Map<IEnumerable<ProdutoResponseContract>>(produtos);
        }

        public async Task<ProdutoResponseContract> ObterPorId(int id)
        {
            var produto = await _repository.ObterPorId(id);
            return _mapper.Map<ProdutoResponseContract>(produto);
        }
    }
}

using AutoMapper;
using EstoqueAPI.Contract.Categoria;
using EstoqueAPI.Domain.Models;
using EstoqueAPI.Domain.Repository.Interface;
using EstoqueAPI.Domain.Service.Interface;

namespace EstoqueAPI.Domain.Service.Class
{
    public class CategoriaService : IBaseService<CategoriaRequestContract, CategoriaResponseContract, int>
    {
        private readonly IBaseRepository<Categoria, int> _repository;
        private readonly IMapper _mapper;
        public CategoriaService(IBaseRepository<Categoria, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoriaResponseContract> Atualizar(int id, CategoriaRequestContract entidade)
        {
            var categoriaExistente = await _repository.ObterPorId(id);

            if (categoriaExistente == null) throw new Exception("Categoria não encontrada");

            var categoriaAtualizada = _mapper.Map<Categoria>(entidade);
            categoriaAtualizada.Id = categoriaExistente.Id;

            await _repository.Atualizar(categoriaAtualizada);

            return _mapper.Map<CategoriaResponseContract>(categoriaAtualizada);
        }

        public async Task<CategoriaResponseContract> Criar(CategoriaRequestContract entidade)
        {
            var categoria = _mapper.Map<Categoria>(entidade);
            await _repository.Criar(categoria);
            return _mapper.Map<CategoriaResponseContract>(categoria);
        }

        public async Task Deletar(int id)
        {
            var categoria = await _repository.ObterPorId(id);
            if (categoria == null) throw new Exception("Categoria não encontrada.");
            await _repository.Deletar(categoria);
        }

        public async Task<IEnumerable<CategoriaResponseContract>> Obter()
        {
            var categorias = await _repository.Obter();
            return _mapper.Map<IEnumerable<CategoriaResponseContract>>(categorias);
        }

        public async Task<CategoriaResponseContract> ObterPorId(int id)
        {
            var categoria = await _repository.ObterPorId(id);
            if (categoria == null) throw new Exception("Categoria não encontrada.");
            return _mapper.Map<CategoriaResponseContract>(categoria);
        }
    }
}

using EstoqueAPI.Data;
using EstoqueAPI.Domain.Models;
using EstoqueAPI.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EstoqueAPI.Domain.Repository.Class
{
    public class MovimentacaoEstoqueRepository : IBaseRepository<MovimentacaoEstoque, int>
    {
        private readonly ApplicationContext _context;
        public MovimentacaoEstoqueRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<MovimentacaoEstoque> Atualizar(MovimentacaoEstoque entidade)
        {
            var movimentacaoEstoque = await ObterPorId(entidade.Id);

            if (movimentacaoEstoque == null) throw new Exception("Movimentação de estoque não encontrada.");

            _context.Entry(movimentacaoEstoque).State = EntityState.Detached;

            _context.MovimentacaoEstoque.Update(entidade);
            await _context.SaveChangesAsync();
            return await ObterPorId(entidade.Id);
        }

        public async Task<MovimentacaoEstoque> Criar(MovimentacaoEstoque entidade)
        {
            await _context.MovimentacaoEstoque.AddAsync(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task Deletar(MovimentacaoEstoque entidade)
        {
            var movimentacaoEstoque = await ObterPorId(entidade.Id);

            if (movimentacaoEstoque == null) throw new Exception("Movimentação de estoque não encontrada.");

            _context.MovimentacaoEstoque.Remove(movimentacaoEstoque);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovimentacaoEstoque>> Obter()
        {
            return await _context.MovimentacaoEstoque.ToListAsync();
        }

        public async Task<MovimentacaoEstoque> ObterPorId(int id)
        {
            return await _context.MovimentacaoEstoque.FindAsync(id) ?? throw new Exception("Movimentação de estoque não encontrada.");
        }
    }
}

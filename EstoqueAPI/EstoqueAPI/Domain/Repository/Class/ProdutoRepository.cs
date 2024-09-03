using EstoqueAPI.Data;
using EstoqueAPI.Domain.Models;
using EstoqueAPI.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EstoqueAPI.Domain.Repository.Class
{
    public class ProdutoRepository : IBaseRepository<Produto, int>
    {
        private readonly ApplicationContext _context;

        public ProdutoRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Produto> Atualizar(Produto entidade)
        {
            var produto = await ObterPorId(entidade.Id);

            if (produto == null) throw new Exception("Produto não encontrado.");

            _context.Produto.Update(produto);
            await _context.SaveChangesAsync();
            return await ObterPorId(entidade.Id);
        }

        public async Task<Produto> Criar(Produto entidade)
        {
            await _context.Produto.AddAsync(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task Deletar(Produto entidade)
        {
            var produto = await ObterPorId(entidade.Id);

            if (produto == null) throw new Exception("Produto não encontrado.");

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> Obter()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<Produto> ObterPorId(int id)
        {
            return await _context.Produto.FindAsync(id) ?? throw new Exception("Produto não encontrado.");
        }
    }
}

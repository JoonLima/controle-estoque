using EstoqueAPI.Data;
using EstoqueAPI.Domain.Models;
using EstoqueAPI.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EstoqueAPI.Domain.Repository.Class
{
    public class CategoriaRepository : IBaseRepository<Categoria, int>
    {
        private readonly ApplicationContext _context;
        public CategoriaRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Categoria> Atualizar(Categoria entidade)
        {
            var categoria = await ObterPorId(entidade.Id);

            if (categoria == null) throw new Exception("Categoria não encontrada.");

            _context.Categoria.Update(entidade);
            await _context.SaveChangesAsync();
            return await ObterPorId(entidade.Id);
        }

        public async Task<Categoria> Criar(Categoria entidade)
        {
            await _context.Categoria.AddAsync(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task Deletar(Categoria entidade)
        {
            var categoria = await ObterPorId(entidade.Id);

            if (categoria == null) throw new Exception("Categoria não encontrada.");

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> Obter()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<Categoria> ObterPorId(int id)
        {
            return await _context.Categoria.FindAsync(id) ?? throw new Exception("Categoria não encontrada.");
        }
    }
}

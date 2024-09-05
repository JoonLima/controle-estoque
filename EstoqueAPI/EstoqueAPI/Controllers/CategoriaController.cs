using EstoqueAPI.Contract.Categoria;
using EstoqueAPI.Contract.Produto;
using EstoqueAPI.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly IBaseService<CategoriaRequestContract, CategoriaResponseContract, int> _service;
        public CategoriaController(IBaseService<CategoriaRequestContract, CategoriaResponseContract, int> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaResponseContract>>> Obter()
        {
            var categorias = await _service.Obter();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaResponseContract>> ObterPorId(int id)
        {
            var categoria = await _service.ObterPorId(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaResponseContract>> Criar([FromBody] CategoriaRequestContract request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var categoriaCriada = await _service.Criar(request);
            return Ok(categoriaCriada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaResponseContract>> Atualizar(int id, [FromBody] CategoriaRequestContract request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var categoriaAtualizada = await _service.Atualizar(id, request);
            if (categoriaAtualizada == null) return NotFound();
            return Ok(categoriaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var categoria = await _service.ObterPorId(id);
            if (categoria == null) return NotFound();
            await _service.Deletar(id);
            return NoContent();
        }

    }
}

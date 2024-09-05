using EstoqueAPI.Contract.Produto;
using EstoqueAPI.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IBaseService<ProdutoRequestContract, ProdutoResponseContract, int> _service;
        public ProdutoController(IBaseService<ProdutoRequestContract, ProdutoResponseContract, int> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoResponseContract>>> Obter()
        {
            var produtos = await _service.Obter();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoResponseContract>> ObterPorId(int id)
        {
            var produto = await _service.ObterPorId(id);
            if(produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoResponseContract>> Criar([FromBody] ProdutoRequestContract request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var produtoCriado = await _service.Criar(request);
            return Created("", produtoCriado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoResponseContract>> Atualizar(int id, [FromBody] ProdutoRequestContract request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var produtoAtualizado = await _service.Atualizar(id, request);
            if (produtoAtualizado == null) return NotFound();
            return Ok(produtoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var produto = await _service.ObterPorId(id);

            if(produto == null) return NotFound();

            await _service.Deletar(id);
            return NoContent();
        }
    }
}

using EstoqueAPI.Contract.MovimentacaoEstoque;
using EstoqueAPI.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("movimentacao-estoque")]
    public class MovimentacaoEstoqueController : ControllerBase
    {
        private readonly IBaseService<MovimentacaoEstoqueRequestContract, MovimentacaoEstoqueResponseContract, int> _service;
        public MovimentacaoEstoqueController(IBaseService<MovimentacaoEstoqueRequestContract, MovimentacaoEstoqueResponseContract, int> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimentacaoEstoqueResponseContract>>> Obter()
        {
            var movimentacaoEstoque = await _service.Obter();
            return Ok(movimentacaoEstoque);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimentacaoEstoqueResponseContract>> ObterPorId(int id)
        {
            var movimentacaoEstoque = await _service.ObterPorId(id);
            return Ok(movimentacaoEstoque);
        }

        [HttpPost]
        public async Task<ActionResult<MovimentacaoEstoqueResponseContract>> Criar([FromBody] MovimentacaoEstoqueRequestContract request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movimentacaoEstoqueCriada = await _service.Criar(request);
            return Ok(movimentacaoEstoqueCriada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovimentacaoEstoqueResponseContract>> Atualizar(int id, [FromBody] MovimentacaoEstoqueRequestContract request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movimentacaoEstoqueAtualizada = await _service.Atualizar(id, request);
            if (movimentacaoEstoqueAtualizada == null) return NotFound();
            return Ok(movimentacaoEstoqueAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var movimentacaoEstoque = await _service.ObterPorId(id);
            if (movimentacaoEstoque == null) return NotFound();
            await _service.Deletar(id);
            return NoContent();
        }
    }
}

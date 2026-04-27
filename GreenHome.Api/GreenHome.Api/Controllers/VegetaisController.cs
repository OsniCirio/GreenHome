using GreenHome.Application.DTO;
using GreenHome.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GreenHome.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VegetaisController : ControllerBase
    {
        private readonly IVegetalService _service;

        public VegetaisController(IVegetalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var dados = await _service.ObterTodosAsync();
            return  Ok(dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(string id)
        {
            var item = await _service.ObterPorIdAsync(id);
            if (item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarVegetalDto dto)
        {
            var item = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(string id, [FromBody] AtualizarVegetalDto dto)
        {
            var atualizado = await _service.AtualizarAsync(id, dto);
            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(string id)
        {
            var removido = await _service.RemoverAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}

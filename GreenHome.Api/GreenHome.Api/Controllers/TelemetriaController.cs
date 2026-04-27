using GreenHome.Application.DTO;
using GreenHome.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetriaController : ControllerBase
    {
        private readonly ITelemetriaService _telemetriaService;

        public TelemetriaController(ITelemetriaService telemetriaService)
        {
            _telemetriaService = telemetriaService;
        }

        [HttpPost("processar")]
        public async Task<IActionResult> Processar([FromBody] TelemetriaRequestDto dto)
        {
            var resposta = await _telemetriaService.ProcessarAsync(dto);
            return Ok(resposta);
        }
        [HttpGet("ultima/{deviceId}")]
        public async Task<IActionResult> Ultima(string deviceId)
        {
         //   var leitura = await _service.ObterUltimaLeitura(deviceId);
           // return Ok(leitura);
           return Ok(new { DeviceId = deviceId, Temperatura = 25.5, Umidade = 60, Luminosidade = 300, DataLeitura = DateTime.UtcNow });
        }
        [HttpGet("historico/{deviceId}")]
        public async Task<IActionResult> Historico(string deviceId)
        {
            var dados = await _telemetriaService.ObterPorDeviceIdAsync(deviceId);
            return Ok(dados);
        }
        [HttpPost("imagem")]
        public async Task<IActionResult> ReceberImagem()
        {
            var fileName = $"foto_{DateTime.Now.Ticks}.jpg";
            var path = Path.Combine("uploads", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await Request.Body.CopyToAsync(stream);
            }

            return Ok(new { mensagem = "Imagem salva", fileName });
        }
    }
}

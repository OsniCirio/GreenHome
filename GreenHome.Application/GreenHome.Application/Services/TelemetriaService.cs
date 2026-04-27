using GreenHome.Application.DTO;
using GreenHome.Application.Interfaces;
using GreenHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Services
{
    public class TelemetriaService : ITelemetriaService
    {
        private readonly ILeituraSensorRepository _leituraRepository;
        private readonly IDispositivoRepository _dispositivoRepository;
        private readonly IRegraCultivoRepository _regraCultivoRepository;

        public TelemetriaService(
            ILeituraSensorRepository leituraRepository,
            IDispositivoRepository dispositivoRepository,
            IRegraCultivoRepository regraCultivoRepository)
        {
            _leituraRepository = leituraRepository;
            _dispositivoRepository = dispositivoRepository;
            _regraCultivoRepository = regraCultivoRepository;
        }

        public async Task<ComandoLedResponseDto> ProcessarAsync(TelemetriaRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.DeviceId))
                throw new InvalidOperationException("DeviceId é obrigatório.");

            var leitura = new LeituraSensor
            {
                DeviceId = dto.DeviceId,
                Temperatura = dto.Temperatura,
                Umidade = dto.Umidade,
                Luminosidade = dto.Luminosidade,
                DataLeitura = DateTime.UtcNow
            };

            await _leituraRepository.CriarAsync(leitura);

            var dispositivo = await _dispositivoRepository.ObterPorDeviceIdAsync(dto.DeviceId);
            if (dispositivo is null)
            {
                return new ComandoLedResponseDto
                {
                    LigarLed = false,
                    Intensidade = 0,
                    CorR = 0,
                    CorG = 0,
                    CorB = 0,
                    Modo = "erro",
                    Mensagem = "Dispositivo não cadastrado."
                };
            }

            var regra = await _regraCultivoRepository.ObterPorVegetalIdAsync(dispositivo.VegetalId);
            if (regra is null)
            {
                return new ComandoLedResponseDto
                {
                    LigarLed = false,
                    Intensidade = 0,
                    CorR = 0,
                    CorG = 0,
                    CorB = 0,
                    Modo = "erro",
                    Mensagem = "Regra de cultivo não encontrada para o vegetal do dispositivo."
                };
            }

            return CalcularComando(leitura, regra);
        }

        private static ComandoLedResponseDto CalcularComando(LeituraSensor leitura, dynamic regra)
        {
            var ligarLed = leitura.Luminosidade < regra.LuminosidadeMinima;

            var intensidade = regra.Intensidade;

            if (leitura.Temperatura > regra.TemperaturaMaxima)
                intensidade -= 20;

            if (leitura.Umidade < regra.UmidadeMinima)
                intensidade -= 10;

            if (intensidade < 0)
                intensidade = 0;

            if (intensidade > 255)
                intensidade = 255;

            return new ComandoLedResponseDto
            {
                LigarLed = ligarLed,
                Intensidade = ligarLed ? intensidade : 0,
                CorR = ligarLed ? regra.CorR : 0,
                CorG = ligarLed ? regra.CorG : 0,
                CorB = ligarLed ? regra.CorB : 0,
                Modo = "automatico",
                Mensagem = ligarLed
                    ? "LED ajustado conforme regra de cultivo."
                    : "Luminosidade suficiente. LED desligado."
            };
        }
        public async Task<List<LeituraSensor>> ObterPorDeviceIdAsync(string deviceId)
        {
            return await _leituraRepository.ObterPorDeviceIdAsync(deviceId);
        }

    }
}

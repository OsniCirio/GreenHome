using GreenHome.Application.DTO;
using GreenHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Interfaces
{
    public interface ITelemetriaService
    {
        Task<List<LeituraSensor>> ObterPorDeviceIdAsync(string deviceId);
        Task<ComandoLedResponseDto> ProcessarAsync(TelemetriaRequestDto dto);
    }
}

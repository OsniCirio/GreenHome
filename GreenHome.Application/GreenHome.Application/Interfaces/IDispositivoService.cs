using GreenHome.Application.DTO;
using GreenHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Interfaces
{
    public interface IDispositivoService
    {
        Task<List<Dispositivo>> ObterTodosAsync();
        Task<Dispositivo?> ObterPorIdAsync(string id);
        Task<Dispositivo> CriarAsync(CriarDispositivoDto dto);
        Task<bool> AtualizarAsync(string id, AtualizarDispositivoDto dto);
        Task<bool> RemoverAsync(string id);
        Task<Dispositivo?> ObterPorDeviceIdAsync(string deviceId);
    }
}

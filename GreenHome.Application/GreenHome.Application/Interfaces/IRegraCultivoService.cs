using GreenHome.Application.DTO;
using GreenHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Interfaces
{
    public interface IRegraCultivoService
    {
        Task<List<RegraCultivo>> ObterTodosAsync();
        Task<RegraCultivo?> ObterPorIdAsync(string id);
        Task<RegraCultivo> CriarAsync(CriarRegraCultivoDto dto);
        Task<bool> AtualizarAsync(string id, AtualizarRegraCultivoDto dto);
        Task<bool> RemoverAsync(string id);
    }
}

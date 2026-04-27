using GreenHome.Application.DTO;
using GreenHome.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Interfaces
{
    public interface IVegetalService
    {
        Task<List<Vegetal>> ObterTodosAsync();
        Task<Vegetal?> ObterPorIdAsync(string id);
        Task<Vegetal> CriarAsync(CriarVegetalDto dto);
        Task<bool> AtualizarAsync(string id, AtualizarVegetalDto dto);
        Task<bool> RemoverAsync(string id);
    }
}

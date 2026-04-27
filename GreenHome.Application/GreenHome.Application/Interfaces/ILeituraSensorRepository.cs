using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHome.Domain.Entities;

namespace GreenHome.Application.Interfaces
{

    public interface ILeituraSensorRepository
    {
        Task CriarAsync(LeituraSensor leitura);
        Task<List<LeituraSensor>> ObterPorDeviceIdAsync(string deviceId);
    }
}

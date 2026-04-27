using GreenHome.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Interfaces
{
    public interface IDispositivoRepository : IMongoRepository<Dispositivo>
    {
        Task<Dispositivo?> ObterPorDeviceIdAsync(string deviceId);
        Task<Dispositivo?> ObterPorIdAsync(string Id);
        Task<DeleteResult?> RemovePorIdAsync(string Id);
    }
}

using GreenHome.Application.Interfaces;
using GreenHome.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Repository
{
    public class DispositivoRepository : MongoRepository<Dispositivo>, IDispositivoRepository
    {
        public DispositivoRepository(IMongoDatabase database)
            : base(database, "dispositivos")
        {
        }

        public async Task<Dispositivo?> ObterPorDeviceIdAsync(string deviceId)
        {
            return await Collection.Find(x => x.DeviceId == deviceId).FirstOrDefaultAsync();
        }
        public async Task<Dispositivo?> ObterPorIdAsync(string Id)
        {
            return await Collection.Find(x => x.Id == Id).FirstOrDefaultAsync();
        }
        public async Task<DeleteResult?> RemovePorIdAsync(string Id)
        {
            return await Collection.DeleteOneAsync(x => x.Id == Id);
        }

    }
}

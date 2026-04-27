using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHome.Application.Interfaces;
using GreenHome.Domain.Entities;
using MongoDB.Driver;


namespace GreenHome.Infrastructure.Repository
{

      public class LeituraSensorRepository : ILeituraSensorRepository
    {
        private readonly IMongoCollection<LeituraSensor> _collection;

        public LeituraSensorRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<LeituraSensor>("leiturasSensores");
        }

        public async Task CriarAsync(LeituraSensor leitura)
        {
            await _collection.InsertOneAsync(leitura);
        }

        public async Task<List<LeituraSensor>> ObterPorDeviceIdAsync(string deviceId)
        {
            return await _collection
                .Find(x => x.DeviceId == deviceId)
                .SortByDescending(x => x.DataLeitura)
                .ToListAsync();
        }
    }
}

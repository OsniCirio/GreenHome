using GreenHome.Application.Interfaces;
using GreenHome.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Repository
{
    public class LeituraRepository : ILeituraRepository
    {
        private readonly IMongoCollection<LeituraSensor> _collection;

        public LeituraRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<LeituraSensor>("leituras");
        }

        public async Task InserirAsync(LeituraSensor leitura)
        {
            await _collection.InsertOneAsync(leitura);
        }
        public async Task<List<LeituraSensor>> ObterPorDeviceIdAsync(string deviceId)
        {
            return await _collection
                .Find(x => x.DeviceId == deviceId)
                .SortByDescending(x => x.DataLeitura) // mais recentes primeiro
                .Limit(50) // evita trazer tudo
                .ToListAsync();
        }
    }
}

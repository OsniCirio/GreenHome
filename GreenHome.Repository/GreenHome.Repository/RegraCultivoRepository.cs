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
    public class RegraCultivoRepository : MongoRepository<RegraCultivo>, IRegraCultivoRepository
    {
        public RegraCultivoRepository(IMongoDatabase database)
            : base(database, "regrasCultivo")
        {
        }

        public async Task<RegraCultivo?> ObterPorVegetalIdAsync(string vegetalId)
        {
            return await Collection.Find(x => x.VegetalId == vegetalId).FirstOrDefaultAsync();
        }
    }
}

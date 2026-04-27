using GreenHome.Application.Interfaces;
using GreenHome.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Repository
{
    public class VegetalRepository : MongoRepository<Vegetal>, IVegetalRepository
    {
        public VegetalRepository(IMongoDatabase database)
            : base(database, "vegetais")
        {
        }

        public async Task<Vegetal?> ObterPorNomeAsync(string nome)
        {
            return await Collection.Find(x => x.Nome == nome).FirstOrDefaultAsync();
        }
        public async Task<Vegetal> ObterPorIdAsync(string id)
        {
            var _first = await Collection
                .Find( i => i.Id == id).FirstOrDefaultAsync();

            return _first;
        }

        public async Task<DeleteResult> RemovePorIdAsync(string id)
        {
            return await Collection.DeleteOneAsync(i => i.Id == id);
        }
    }
}

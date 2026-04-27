using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHome.Application.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;


namespace GreenHome.Repository
{



    public class MongoRepository<T> : IMongoRepository<T>
    {
        protected readonly IMongoCollection<T> Collection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            Collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> ObterTodosAsync()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }

        public async Task<T?> ObterPorIdAsync(string id)
        {
            return await Collection
                .Find(Builders<T>.Filter.Eq("id", id))
                .FirstOrDefaultAsync();


        }

        public async Task CriarAsync(T entidade)
        {
            await Collection.InsertOneAsync(entidade);
        }

        public async Task AtualizarAsync(string id, T entidade)
        {
            await Collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entidade);
        }

        public async Task RemoverAsync(string id)
        {
            await Collection.DeleteOneAsync(Builders<T>.Filter.Eq("id", id));
        }
    }
}

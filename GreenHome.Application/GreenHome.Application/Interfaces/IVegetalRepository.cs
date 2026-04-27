using GreenHome.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Interfaces
{
    public interface IVegetalRepository : IMongoRepository<Vegetal>
    {
        Task<Vegetal?> ObterPorNomeAsync(string nome);
        Task<Vegetal?> ObterPorIdAsync(string id);

        Task<DeleteResult> RemovePorIdAsync(string id);
    }
}

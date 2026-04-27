using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Interfaces
{
    public interface IMongoRepository<T>
    {
        Task<List<T>> ObterTodosAsync();
        Task<T?> ObterPorIdAsync(string id);
        Task CriarAsync(T entidade);
        Task AtualizarAsync(string id, T entidade);
        Task RemoverAsync(string id);
    }
}

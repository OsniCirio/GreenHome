using GreenHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Interfaces
{
    public interface IRegraCultivoRepository : IMongoRepository<RegraCultivo>
    {
        Task<RegraCultivo?> ObterPorVegetalIdAsync(string vegetalId);
    }
}

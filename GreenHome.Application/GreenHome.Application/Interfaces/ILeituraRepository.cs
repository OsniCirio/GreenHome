using GreenHome.Domain.Entities;

namespace GreenHome.Application.Interfaces
{
    public interface ILeituraRepository
    {
        Task InserirAsync(LeituraSensor leitura);
        Task<List<LeituraSensor>> ObterPorDeviceIdAsync(string deviceId);
    }
}
using GreenHome.Application.DTO;
using GreenHome.Application.Interfaces;
using GreenHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Services
{
    public class DispositivoService : IDispositivoService
    {
        private readonly IDispositivoRepository _repository;
        private readonly IVegetalRepository _vegetalRepository;

        public DispositivoService(
            IDispositivoRepository repository,
            IVegetalRepository vegetalRepository)
        {
            _repository = repository;
            _vegetalRepository = vegetalRepository;
        }

        public async Task<List<Dispositivo>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<Dispositivo?> ObterPorIdAsync(string id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<Dispositivo> CriarAsync(CriarDispositivoDto dto)
        {
            var existente = await _repository.ObterPorDeviceIdAsync(dto.DeviceId);
            if (existente is not null)
                throw new InvalidOperationException("Já existe dispositivo com esse DeviceId.");

            var vegetal = await _vegetalRepository.ObterPorIdAsync(dto.VegetalId);
            if (vegetal is null)
                throw new InvalidOperationException("Vegetal não encontrado.");

            var dispositivo = new Dispositivo
            {
                Nome = dto.Nome,
                DeviceId = dto.DeviceId,
                VegetalId = dto.VegetalId,
                Localizacao = dto.Localizacao,
                Ativo = true,
                DataCriacao = DateTime.UtcNow
            };

            await _repository.CriarAsync(dispositivo);
            return dispositivo;
        }

        public async Task<bool> AtualizarAsync(string id, AtualizarDispositivoDto dto)
        {
            var existente = await _repository.ObterPorIdAsync(id);
            if (existente is null)
                return false;

            var vegetal = await _vegetalRepository.ObterPorIdAsync(dto.VegetalId);
            if (vegetal is null)
                throw new InvalidOperationException("Vegetal não encontrado.");

            existente.Nome = dto.Nome;
            existente.VegetalId = dto.VegetalId;
            existente.Localizacao = dto.Localizacao;
            existente.Ativo = dto.Ativo;
            existente.DataAtualizacao = DateTime.UtcNow;

            await _repository.AtualizarAsync(id, existente);
            return true;
        }

        public async Task<bool> RemoverAsync(string id)
        {
            var existente = await _repository.ObterPorIdAsync(id);
            if (existente is null)
                return false;

            await _repository.RemovePorIdAsync(id);
            return true;
        }
        public async Task<Dispositivo?> ObterPorDeviceIdAsync(string deviceId)
        {
            var dados = await _repository.ObterPorDeviceIdAsync(deviceId);
            return dados;
        }
    }
}

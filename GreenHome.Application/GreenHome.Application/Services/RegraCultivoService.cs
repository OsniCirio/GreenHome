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
    public class RegraCultivoService : IRegraCultivoService
    {
        private readonly IRegraCultivoRepository _repository;
        private readonly IVegetalRepository _vegetalRepository;

        public RegraCultivoService(
            IRegraCultivoRepository repository,
            IVegetalRepository vegetalRepository)
        {
            _repository = repository;
            _vegetalRepository = vegetalRepository;
        }

        public async Task<List<RegraCultivo>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<RegraCultivo?> ObterPorIdAsync(string id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<RegraCultivo> CriarAsync(CriarRegraCultivoDto dto)
        {
            var vegetal = await _vegetalRepository.ObterPorIdAsync(dto.VegetalId);
            if (vegetal is null)
                throw new InvalidOperationException("Vegetal não encontrado.");

            var regraExistente = await _repository.ObterPorVegetalIdAsync(dto.VegetalId);
            if (regraExistente is not null)
                throw new InvalidOperationException("Já existe regra cadastrada para esse vegetal.");

            var regra = new RegraCultivo
            {
                VegetalId = dto.VegetalId,
                TemperaturaMinima = dto.TemperaturaMinima,
                TemperaturaMaxima = dto.TemperaturaMaxima,
                UmidadeMinima = dto.UmidadeMinima,
                UmidadeMaxima = dto.UmidadeMaxima,
                LuminosidadeMinima = dto.LuminosidadeMinima,
                LuminosidadeMaxima = dto.LuminosidadeMaxima,
                CorR = dto.CorR,
                CorG = dto.CorG,
                CorB = dto.CorB,
                Intensidade = dto.Intensidade,
                Ativo = true,
                DataCriacao = DateTime.UtcNow
            };

            await _repository.CriarAsync(regra);
            return regra;
        }

        public async Task<bool> AtualizarAsync(string id, AtualizarRegraCultivoDto dto)
        {
            var existente = await _repository.ObterPorIdAsync(id);
            if (existente is null)
                return false;

            var vegetal = await _vegetalRepository.ObterPorIdAsync(dto.VegetalId);
            if (vegetal is null)
                throw new InvalidOperationException("Vegetal não encontrado.");

            existente.VegetalId = dto.VegetalId;
            existente.TemperaturaMinima = dto.TemperaturaMinima;
            existente.TemperaturaMaxima = dto.TemperaturaMaxima;
            existente.UmidadeMinima = dto.UmidadeMinima;
            existente.UmidadeMaxima = dto.UmidadeMaxima;
            existente.LuminosidadeMinima = dto.LuminosidadeMinima;
            existente.LuminosidadeMaxima = dto.LuminosidadeMaxima;
            existente.CorR = dto.CorR;
            existente.CorG = dto.CorG;
            existente.CorB = dto.CorB;
            existente.Intensidade = dto.Intensidade;
            existente.DataAtualizacao = DateTime.UtcNow;

            await _repository.AtualizarAsync(id, existente);
            return true;
        }

        public async Task<bool> RemoverAsync(string id)
        {
            var existente = await _repository.ObterPorIdAsync(id);
            if (existente is null)
                return false;

            await _repository.RemoverAsync(id);
            return true;
        }
    }
}

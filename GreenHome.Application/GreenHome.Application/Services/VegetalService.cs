using GreenHome.Application.DTO;
using GreenHome.Application.Interfaces;
using GreenHome.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.Services
{
    public class VegetalService : IVegetalService
    {
        private readonly IVegetalRepository _repository;

        public VegetalService(IVegetalRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Vegetal>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<Vegetal?> ObterPorIdAsync(string id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<Vegetal> CriarAsync(CriarVegetalDto dto)
        {
            var existente = await _repository.ObterPorNomeAsync(dto.Nome);
            if (existente is not null)
                throw new InvalidOperationException("Já existe um vegetal com esse nome.");

            var vegetal = new Vegetal
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Ativo = true,
                DataCriacao = DateTime.UtcNow
            };

            await _repository.CriarAsync(vegetal);
            return vegetal;
        }

        public async Task<bool> AtualizarAsync(string id, AtualizarVegetalDto dto)
        {
            var existente = await _repository.ObterPorIdAsync(id);
            if (existente is null)
                return false;

            existente.Nome = dto.Nome;
            existente.Descricao = dto.Descricao;
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
    }
}

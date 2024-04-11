using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_ecommerce_maxima_tech.Application.DTOs;
using api_ecommerce_maxima_tech.Application.Interfaces;
using api_ecommerce_maxima_tech.Domain.Entities;
using api_ecommerce_maxima_tech.Domain.Interfaces;

namespace api_ecommerce_maxima_tech.Application.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<IEnumerable<DepartamentoDto>> GetAllDepartamentoAsync()
        {
            var departamentos = await _departamentoRepository.GetAllAsync();
            var departamentoDtos = departamentos.Select(departamento => new DepartamentoDto
            {
                Id = departamento.Id,
                Codigo = departamento.Codigo,
                Descricao = departamento.Descricao,
            }).ToList();

            return departamentoDtos;
        }

        public async Task<DepartamentoDto> GetDepartamentoByIdAsync(Guid id)
        {
            var departamento = await _departamentoRepository.GetByIdAsync(id);
            if (departamento == null) return null;

            return new DepartamentoDto
            {
                Id = departamento.Id,
                Codigo = departamento.Codigo,
                Descricao = departamento.Descricao,
            };
        }



    }

}

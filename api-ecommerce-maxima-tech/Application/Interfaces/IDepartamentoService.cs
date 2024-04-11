using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_ecommerce_maxima_tech.Application.DTOs;

namespace api_ecommerce_maxima_tech.Application.Interfaces
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<DepartamentoDto>> GetAllDepartamentoAsync();
        Task<DepartamentoDto> GetDepartamentoByIdAsync(Guid id);
    }
}
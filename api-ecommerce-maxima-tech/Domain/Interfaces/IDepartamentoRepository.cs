using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_ecommerce_maxima_tech.Domain.Entities;

namespace api_ecommerce_maxima_tech.Domain.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> GetAllAsync();
        Task<Departamento> GetByIdAsync(Guid id);

    }
}
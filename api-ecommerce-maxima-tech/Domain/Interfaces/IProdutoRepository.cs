using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_ecommerce_maxima_tech.Domain.Entities;

namespace api_ecommerce_maxima_tech.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(Guid id);
        Task CreateAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Guid id);
    }
}
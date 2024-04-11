using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_ecommerce_maxima_tech.Application.DTOs;

namespace api_ecommerce_maxima_tech.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> GetAllProdutosAsync();
        Task<ProdutoDto> GetProdutoByIdAsync(Guid id);
        Task<ProdutoDto> CreateProdutoAsync(ProdutoDto produtoDto);
        Task UpdateProdutoAsync(Guid id, ProdutoDto produtoDto);
        Task DeleteProdutoAsync(Guid id);
    }
}
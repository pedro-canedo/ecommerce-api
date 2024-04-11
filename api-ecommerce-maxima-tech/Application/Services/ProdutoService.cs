using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_ecommerce_maxima_tech.Application.DTOs;
using api_ecommerce_maxima_tech.Application.Interfaces;
using api_ecommerce_maxima_tech.Domain.Entities;
using api_ecommerce_maxima_tech.Domain.Interfaces;

namespace api_ecommerce_maxima_tech.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllProdutosAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            var produtoDtos = produtos.Select(produto => new ProdutoDto
            {
                Id = produto.Id,
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                DepartamentoId = produto.DepartamentoId,
                Preco = produto.Preco,
                Status = produto.Status,
            }).ToList();

            return produtoDtos;
        }

        public async Task<ProdutoDto> GetProdutoByIdAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null) return null;

            return new ProdutoDto
            {
                Id = produto.Id,
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                DepartamentoId = produto.DepartamentoId,
                Preco = produto.Preco,
                Status = produto.Status,
            };
        }

        public async Task<ProdutoDto> CreateProdutoAsync(ProdutoDto produtoDto)
        {
            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Codigo = produtoDto.Codigo,
                Descricao = produtoDto.Descricao,
                DepartamentoId = produtoDto.DepartamentoId,
                Preco = produtoDto.Preco,
                Status = produtoDto.Status,
                IsDeleted = false,
                Operation = "CREATE",
                OperationTimestamp = DateTime.UtcNow
            };

            await _produtoRepository.CreateAsync(produto);

            produtoDto.Id = produto.Id;
            return produtoDto;
        }

        public async Task UpdateProdutoAsync(Guid id, ProdutoDto produtoDto)
        {
            var produtoExistente = await _produtoRepository.GetByIdAsync(id);
            if (produtoExistente == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }

            produtoExistente.Codigo = produtoDto.Codigo;
            produtoExistente.Descricao = produtoDto.Descricao;
            produtoExistente.DepartamentoId = produtoDto.DepartamentoId;
            produtoExistente.Preco = produtoDto.Preco;
            produtoExistente.Status = produtoDto.Status;
            produtoExistente.Operation = "UPDATE";
            produtoExistente.OperationTimestamp = DateTime.UtcNow;

            await _produtoRepository.UpdateAsync(produtoExistente);
        }

        public async Task DeleteProdutoAsync(Guid id)
        {
            var produtoExistente = await _produtoRepository.GetByIdAsync(id);
            if (produtoExistente == null)
            {
                throw new KeyNotFoundException("Produto não encontrado para exclusão.");
            }
            produtoExistente.IsDeleted = true;
            produtoExistente.Operation = "DELETE";
            produtoExistente.OperationTimestamp = DateTime.UtcNow;

            await _produtoRepository.UpdateAsync(produtoExistente);
        }
    }
}

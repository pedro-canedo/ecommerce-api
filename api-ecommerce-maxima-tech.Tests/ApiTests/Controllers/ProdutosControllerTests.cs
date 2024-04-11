using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using api_ecommerce_maxima_tech.Api.Controllers;
using api_ecommerce_maxima_tech.Application.DTOs;
using api_ecommerce_maxima_tech.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_ecommerce_maxima_tech.Tests.ApiTests.Controllers
{
    public class ProdutosControllerTests
    {
        private readonly Mock<IProdutoService> _mockProdutoService;
        private readonly ProdutosController _controller;

        public ProdutosControllerTests()
        {
            _mockProdutoService = new Mock<IProdutoService>();
            _controller = new ProdutosController(_mockProdutoService.Object);
        }

        [Fact]
        public async Task GetAllProdutos_ReturnsOk_WithAListOfProdutos()
        {
            _mockProdutoService.Setup(s => s.GetAllProdutosAsync()).ReturnsAsync(new List<ProdutoDto> { new ProdutoDto(), new ProdutoDto() });

            var result = await _controller.GetAllProdutos();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ProdutoDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetProdutoById_ReturnsOk_WithProduto()
        {
            var produtoId = Guid.NewGuid();
            _mockProdutoService.Setup(s => s.GetProdutoByIdAsync(produtoId)).ReturnsAsync(new ProdutoDto { Id = produtoId });

            var result = await _controller.GetProdutoById(produtoId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var produto = Assert.IsType<ProdutoDto>(okResult.Value);
            Assert.Equal(produtoId, produto.Id);
        }

        [Fact]
        public async Task CreateProduto_ReturnsCreatedAtAction_WithProduto()
        {
            var produtoDto = new ProdutoDto();
            _mockProdutoService.Setup(s => s.CreateProdutoAsync(produtoDto)).ReturnsAsync(produtoDto);

            var result = await _controller.CreateProduto(produtoDto);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetProdutoById", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task UpdateProduto_ReturnsNoContent()
        {
            var produtoId = Guid.NewGuid();
            var produtoDto = new ProdutoDto { Id = produtoId };
            _mockProdutoService.Setup(s => s.UpdateProdutoAsync(produtoId, produtoDto)).Returns(Task.CompletedTask);

            var result = await _controller.UpdateProduto(produtoId, produtoDto);

            Assert.IsType<NoContentResult>(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api_ecommerce_maxima_tech.Application.DTOs;
using Xunit;

namespace api_ecommerce_maxima_tech.Tests.DTOs
{
    public class ProdutoDtoTests
    {
        [Fact]
        public void ProdutoDto_Validations_ShouldBeValid()
        {
            var produtoDto = new ProdutoDto
            {
                Codigo = "ABC123",
                Descricao = "Produto Teste",
                DepartamentoId = Guid.NewGuid(),
                Preco = 100.00M,
                Status = true
            };

            var context = new ValidationContext(produtoDto, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(produtoDto, context, results, true);

            Assert.True(isValid);
            Assert.Empty(results);
        }

        [Theory]
        [InlineData(null, "Descricao", "DepartamentoId", 0.0)]
        [InlineData("", "Descricao", "DepartamentoId", -1.0)]
        public void ProdutoDto_Validations_ShouldBeInvalid(string codigo, string descricao, string departamentoId, decimal preco)
        {
            // Arrange
            var produtoDto = new ProdutoDto
            {
                Codigo = codigo,
                Descricao = descricao,
                DepartamentoId = Guid.Empty, // Para simplificar o teste
                Preco = preco,
                Status = true
            };

            var context = new ValidationContext(produtoDto, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(produtoDto, context, results, true);

            Assert.False(isValid);
            Assert.NotEmpty(results);
        }
    }
}

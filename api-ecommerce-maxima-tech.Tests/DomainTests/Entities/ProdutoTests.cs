using System;
using Xunit;
using api_ecommerce_maxima_tech.Domain.Entities;

namespace api_ecommerce_maxima_tech.Tests.Entities
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var codigo = "PRD100";
            var descricao = "Produto Teste";
            var departamentoId = Guid.NewGuid();
            var preco = 150.50m;
            var status = true;

            // Act
            var produto = new Produto
            {
                Id = id,
                Codigo = codigo,
                Descricao = descricao,
                DepartamentoId = departamentoId,
                Preco = preco,
                Status = status
            };

            // Assert
            Assert.Equal(id, produto.Id);
            Assert.Equal(codigo, produto.Codigo);
            Assert.Equal(descricao, produto.Descricao);
            Assert.Equal(departamentoId, produto.DepartamentoId);
            Assert.Equal(preco, produto.Preco);
            Assert.Equal(status, produto.Status);
        }
    }
}

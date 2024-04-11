using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_ecommerce_maxima_tech.Domain.Entities;
using api_ecommerce_maxima_tech.Domain.Interfaces;
using System.Data;
namespace api_ecommerce_maxima_tech.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            var produtos = new List<Produto>();

            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            var query = "SELECT id, codigo, descricao, departamentoid, preco, status FROM produtos WHERE is_deleted = FALSE";
            await using var cmd = new NpgsqlCommand(query, conn);
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                produtos.Add(new Produto
                {
                    Id = reader.GetGuid("id"),
                    Codigo = reader.GetString("codigo"),
                    Descricao = reader.GetString("descricao"),
                    DepartamentoId = reader.GetGuid("departamentoid"),
                    Preco = reader.GetDecimal("preco"),
                    Status = reader.GetBoolean("status"),
                });
            }

            return produtos;
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            var query = "SELECT id, codigo, descricao, departamentoid, preco, status FROM produtos WHERE id = @id AND is_deleted = FALSE";
            await using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id", id);
            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Produto
                {
                    Id = reader.GetGuid("id"),
                    Codigo = reader.GetString("codigo"),
                    Descricao = reader.GetString("descricao"),
                    DepartamentoId = reader.GetGuid("departamentoid"),
                    Preco = reader.GetDecimal("preco"),
                    Status = reader.GetBoolean("status"),
                };
            }

            return null;
        }

        public async Task CreateAsync(Produto produto)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            var query = "INSERT INTO produtos (id, codigo, descricao, departamentoid, preco, status, is_deleted, operation, operation_timestamp) VALUES (@id, @codigo, @descricao, @departamentoid, @preco, @status, @is_deleted, @operation, @operation_timestamp)";
            await using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id", produto.Id);
            cmd.Parameters.AddWithValue("codigo", produto.Codigo);
            cmd.Parameters.AddWithValue("descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("departamentoid", produto.DepartamentoId);
            cmd.Parameters.AddWithValue("preco", produto.Preco);
            cmd.Parameters.AddWithValue("status", produto.Status);
            cmd.Parameters.AddWithValue("is_deleted", produto.IsDeleted);
            cmd.Parameters.AddWithValue("operation", "CREATE");
            cmd.Parameters.AddWithValue("operation_timestamp", DateTime.UtcNow);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            var query = "UPDATE produtos SET codigo = @codigo, descricao = @descricao, departamentoid = @departamentoid, preco = @preco, status = @status, is_deleted = @is_deleted, operation = @operation, operation_timestamp = @operation_timestamp WHERE id = @id";
            await using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id", produto.Id);
            cmd.Parameters.AddWithValue("codigo", produto.Codigo);
            cmd.Parameters.AddWithValue("descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("departamentoid", produto.DepartamentoId);
            cmd.Parameters.AddWithValue("preco", produto.Preco);
            cmd.Parameters.AddWithValue("status", produto.Status);
            cmd.Parameters.AddWithValue("is_deleted", produto.IsDeleted);
            cmd.Parameters.AddWithValue("operation", "UPDATE");
            cmd.Parameters.AddWithValue("operation_timestamp", DateTime.UtcNow);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            var query = "UPDATE produtos SET is_deleted = TRUE, operation = 'DELETE', operation_timestamp = NOW() WHERE id = @id";
            await using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id", id);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
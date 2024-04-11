using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_ecommerce_maxima_tech.Domain.Entities;
using api_ecommerce_maxima_tech.Domain.Interfaces;
using System.Data;

namespace api_ecommerce_maxima_tech.Infrastructure.Data.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly string _connectionString;

        public DepartamentoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            var departamento = new List<Departamento>();

            await using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (var cmd = new NpgsqlCommand("SELECT id, codigo, descricao FROM departamentos", conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            departamento.Add(new Departamento
                            {
                                Id = reader.GetGuid(0),
                                Codigo = reader.GetString(1),
                                Descricao = reader.GetString(2),
                            });
                        }
                    }
                }
            }

            return departamento;
        }

        public async Task<Departamento> GetByIdAsync(Guid id)
        {
            Departamento departamento = null;

            await using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await using (var cmd = new NpgsqlCommand("SELECT id, codigo, descricao FROM departamentos WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            departamento = new Departamento
                            {
                                Id = reader.GetGuid(0),
                                Codigo = reader.GetString(1),
                                Descricao = reader.GetString(2),
                            };
                        }
                    }
                }
            }

            return departamento;
        }

    }
}

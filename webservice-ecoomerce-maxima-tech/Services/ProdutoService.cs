using webservice_ecoomerce_maxima_tech.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

public class ProdutoService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;


    public ProdutoService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");

    }
    public async Task<IEnumerable<ProdutoModel>> GetProdutosAsync()
    {
        var url = $"{_baseUrl}/Produtos";
        return await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoModel>>(url);
    }


    public async Task<ProdutoModel> GetProdutoByIdAsync(Guid id)
    {
        var url = $"{_baseUrl}/Produtos";
        return await _httpClient.GetFromJsonAsync<ProdutoModel>($"{url}/{id}");
    }

    public async Task CreateProdutoAsync(ProdutoModel produto)
    {
        var url = $"{_baseUrl}/Produtos";
        await _httpClient.PostAsJsonAsync(url, produto);
    }

    public async Task UpdateProdutoAsync(ProdutoModel produto)
    {
        var url = $"{_baseUrl}/Produtos";
        await _httpClient.PutAsJsonAsync($"{url}/{produto.Id}", produto);
    }

    public async Task DeleteProdutoAsync(Guid id)
    {
        var url = $"{_baseUrl}/Produtos";
        await _httpClient.DeleteAsync($"{url}/{id}");
    }

    public async Task<IEnumerable<DepartamentoModel>> GetDepartamentosAsync()
    {
        var departamentoUrl = $"{_baseUrl}/Departamento";
        try
        {
            var departamentos = await _httpClient.GetFromJsonAsync<IEnumerable<DepartamentoModel>>(departamentoUrl);

            return departamentos ?? new List<DepartamentoModel>();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
            return new List<DepartamentoModel>();
        }
    }

}

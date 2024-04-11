using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api_ecommerce_maxima_tech.Application.DTOs;
using api_ecommerce_maxima_tech.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_ecommerce_maxima_tech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartamento()
        {
            var departamentos = await _departamentoService.GetAllDepartamentoAsync();
            return Ok(departamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartamentoById(Guid id)
        {
            var departamento = await _departamentoService.GetDepartamentoByIdAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return Ok(departamento);
        }
    }
}
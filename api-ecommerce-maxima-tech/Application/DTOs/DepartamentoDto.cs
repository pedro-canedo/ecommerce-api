using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecommerce_maxima_tech.Application.DTOs
{
    public class DepartamentoDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(10)]
        public string Descricao { get; set; }
    }
}
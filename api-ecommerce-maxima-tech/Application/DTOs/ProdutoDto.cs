using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_ecommerce_maxima_tech.Application.DTOs
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O código é obrigatório.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O departamento é obrigatório.")]
        public Guid DepartamentoId { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que 0.")]
        public decimal Preco { get; set; }

        public bool Status { get; set; }
    }
}

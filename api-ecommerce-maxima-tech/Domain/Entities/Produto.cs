using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace api_ecommerce_maxima_tech.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public Guid DepartamentoId { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }

        public DateTime OperationTimestamp { get; internal set; }
        public string Operation { get; internal set; }
        public bool IsDeleted { get; internal set; }
    }
}
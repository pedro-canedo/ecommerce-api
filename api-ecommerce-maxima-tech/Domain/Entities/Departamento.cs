using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_ecommerce_maxima_tech.Domain.Entities
{
    public class Departamento
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
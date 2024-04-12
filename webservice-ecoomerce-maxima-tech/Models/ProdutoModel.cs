
namespace webservice_ecoomerce_maxima_tech.Models

{
    public class ProdutoModel
    {
        public Guid Id { get; set; }
        public string ?Codigo { get; set; }
        public string ?Descricao { get; set; }
        public Guid DepartamentoId { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
    }


}

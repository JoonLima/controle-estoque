namespace EstoqueAPI.Domain.Models
{
    public class MovimentacaoEstoque
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string TipoMovimentacao { get; set; } = string.Empty;
        public string? Observacao { get; set; }
    }
}

using EstoqueAPI.Domain.Models;

namespace EstoqueAPI.Contract.Produto
{
    public class ProdutoResponseContract
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int IdCategoria { get; set; }
    }
}

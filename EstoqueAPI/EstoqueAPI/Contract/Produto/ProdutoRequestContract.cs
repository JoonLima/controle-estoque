using EstoqueAPI.Domain.Models;

namespace EstoqueAPI.Contract.Produto
{
    public class ProdutoRequestContract
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int IdCategoria { get; set; }
    }
}

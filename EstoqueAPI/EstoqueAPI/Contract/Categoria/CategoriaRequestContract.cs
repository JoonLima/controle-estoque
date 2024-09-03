namespace EstoqueAPI.Contract.Categoria
{
    public class CategoriaRequestContract
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }
}

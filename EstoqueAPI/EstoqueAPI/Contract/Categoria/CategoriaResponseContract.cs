namespace EstoqueAPI.Contract.Categoria
{
    public class CategoriaResponseContract
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }
}

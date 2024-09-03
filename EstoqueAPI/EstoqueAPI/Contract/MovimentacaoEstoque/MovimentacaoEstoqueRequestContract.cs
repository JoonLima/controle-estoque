﻿namespace EstoqueAPI.Contract.MovimentacaoEstoque
{
    public class MovimentacaoEstoqueRequestContract
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public string TipoMovimentacao { get; set; } = string.Empty;
        public string? Observacao { get; set; }
    }
}

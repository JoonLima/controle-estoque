export default class MovimentacaoEstoque {
  constructor(obj = {}) {
    this.id = obj.id;
    this.idProduto = obj.idProduto;
    this.quantidade = obj.quantidade;
    this.dataMovimentacao = obj.dataMovimentacao || '';
    this.tipoMovimentacao = obj.tipoMovimentacao;
    this.observacao = obj.observacao;
  }

  modeloValido() {
    return !!(this.idProduto && this.quantidade && this.tipoMovimentacao);
  }
}

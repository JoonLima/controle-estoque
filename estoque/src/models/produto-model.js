export default class Produto {
  constructor(obj = {}) {
    this.id = obj.id;
    this.nome = obj.nome;
    this.descricao = obj.descricao;
    this.preco = obj.preco || 0;
    this.quantidadeEstoque = obj.quantidadeEstoque || 0;
    this.idCategoria = obj.idCategoria;
  }

  modeloValido() {
    return !!(
      this.nome &&
      this.quantidadeEstoque &&
      this.preco &&
      this.idCategoria
    );
  }
}

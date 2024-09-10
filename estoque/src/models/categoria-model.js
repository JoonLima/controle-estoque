export default class Categoria {
  constructor(obj = {}) {
    this.id = obj.id;
    this.nome = obj.nome;
    this.descricao = obj.descricao;
  }

  modeloValido() {
    return !!this.nome;
  }
}

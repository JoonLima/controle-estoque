const COLUNAS_TABELA_PRODUTO = [
  { title: 'ID', align: 'start', key: 'id' },
  { title: 'Nome', key: 'nome' },
  { title: 'Qtd. Estoque', key: 'quantidadeEstoque' },
  { title: 'Preço', key: 'preco' },
  { title: 'Categoria', key: 'idCategoria' },
  { title: 'Descrição', key: 'descricao' },
  { title: '', key: 'acao', sortable: false, width: '100px', align: 'center' },
];

const COLUNAS_TABELA_CATEGORIA = [
  { title: 'ID', align: 'start', key: 'id' },
  { title: 'Nome', key: 'nome' },
  { title: 'Descrição', key: 'descricao' },
  { title: '', key: 'acao', sortable: false, width: '100px', align: 'center' },
];

const COLUNAS_TABELA_MOVIMENTACAO = [
  { title: 'ID', align: 'start', key: 'id' },
  { title: 'Tipo', key: 'tipoMovimentacao' },
  { title: 'Produto', key: 'idProduto' },
  { title: 'Quantidade', key: 'quantidade' },
  { title: 'Data', key: 'dataMovimentacao' },
  { title: '', key: 'acao', sortable: false, width: '100px', align: 'center' },
];

export {
  COLUNAS_TABELA_PRODUTO,
  COLUNAS_TABELA_CATEGORIA,
  COLUNAS_TABELA_MOVIMENTACAO,
};

const COLUNAS_TABELA_PRODUTO = [
  { title: 'ID', align: 'start', key: 'id' },
  { title: 'Nome', key: 'nome' },
  { title: 'Qtd. Estoque', key: 'quantidadeEstoque' },
  { title: 'Preço', key: 'preco' },
  { title: 'Categoria', key: 'idCategoria' },
  { title: 'Descrição', key: 'descricao' },
  { title: '', key: 'acao', sortable: false },
];

const COLUNAS_TABELA_CATEGORIA = [
  { text: 'Código', value: 'id' },
  { text: 'Nome', value: 'nome' },
  { text: 'Valor', value: 'valor' },
  { text: 'Quantidade', value: 'quantidadeEstoque' },
  { text: 'Observação', value: 'observacao' },
  { text: 'Data cadastro', value: 'dataCadastro' },
  { text: 'Actions', value: 'actions', sortable: false },
];

const COLUNAS_TABELA_MOVIMENTACAO = [
  { text: 'Código', value: 'id' },
  { text: 'Nome', value: 'nome' },
  { text: 'Valor', value: 'valor' },
  { text: 'Quantidade', value: 'quantidadeEstoque' },
  { text: 'Observação', value: 'observacao' },
  { text: 'Data cadastro', value: 'dataCadastro' },
  { text: 'Actions', value: 'actions', sortable: false },
];

export {
  COLUNAS_TABELA_PRODUTO,
  COLUNAS_TABELA_CATEGORIA,
  COLUNAS_TABELA_MOVIMENTACAO,
};

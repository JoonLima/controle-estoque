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
  { text: 'Código', value: 'id' },
  { text: 'Nome', value: 'nome' },
  { text: 'Valor', value: 'valor' },
  { text: 'Quantidade', value: 'quantidadeEstoque' },
  { text: 'Observação', value: 'observacao' },
  { text: 'Data cadastro', value: 'dataCadastro' },
  { title: '', key: 'acao', sortable: false, width: '100px', align: 'center' },
];

export {
  COLUNAS_TABELA_PRODUTO,
  COLUNAS_TABELA_CATEGORIA,
  COLUNAS_TABELA_MOVIMENTACAO,
};

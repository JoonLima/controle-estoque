<template>
  <v-data-table
    :headers="headers"
    :items="movimentacoes"
    :sort-by="[{ key: 'id', order: 'asc' }]"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-dialog v-model="abrirModal" max-width="70%">
          <template v-slot:activator="{ props }">
            <v-btn
              class="mb-2"
              variant="outlined"
              prepend-icon="mdi-plus"
              @click="novaMovimentacao"
              v-bind="props"
            >
              Nova movimentação
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ modoEdicao ? 'Editar' : 'Novo' }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="2" md="2" sm="2">
                    <v-text-field
                      v-model="movimentacaoEstoque.id"
                      disabled
                      label="ID"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="10" md="10" sm="10">
                    <v-autocomplete
                      v-model="movimentacaoEstoque.idProduto"
                      :items="produtos"
                      label="Produtos"
                      clearable
                      item-value="id"
                      item-title="nome"
                      prepend-icon="mdi-package-variant-closed"
                      persistent-hint
                    ></v-autocomplete>
                  </v-col>
                  <v-col cols="4" md="4" sm="10">
                    <v-select
                      v-model="movimentacaoEstoque.tipoMovimentacao"
                      :items="['Saída', 'Entrada']"
                      label="Tipo da Movimentação"
                    ></v-select>
                  </v-col>
                  <v-col cols="2" md="2" sm="12">
                    <v-text-field
                      v-model="quantidadeEstoqueProduto"
                      disabled
                      label="Estoque"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="2" md="2" sm="12">
                    <v-text-field
                      v-model="movimentacaoEstoque.quantidade"
                      label="Quantidade"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4" md="4" sm="12">
                    <v-text-field
                      v-model="movimentacaoEstoque.dataMovimentacao"
                      type="date"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="12" sm="12">
                    <v-text-field
                      v-model="movimentacaoEstoque.observacao"
                      label="Observação"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="primary" variant="flat" @click="salvar">
                Salvar
              </v-btn>
              <v-btn
                color="primary"
                variant="outlined"
                @click="abrirModal = false"
              >
                Cancelar
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:[`item.idProduto`]="{ item }">
      <span>{{ getProdutoNome(item.idProduto) }}</span>
    </template>
    <template v-slot:[`item.dataMovimentacao`]="{ item }">
      <span>{{ dataFormatada(item.dataMovimentacao) }}</span>
    </template>
    <template v-slot:[`item.acao`]="{ item }">
      <v-icon class="me-2" size="small" @click="editar(item)">
        mdi-pencil
      </v-icon>
      <v-icon size="small" @click="deletar(item)"> mdi-delete </v-icon>
    </template>
    <template v-slot:no-data>
      <span>Nenhum item</span>
    </template>
  </v-data-table>

  <!-- modal deletar -->
  <v-dialog v-model="dialogDelete" max-width="500px">
    <v-card>
      <v-card-title class="text-h5"
        >Deseja excluir a movimentação ID:
        {{ movimentacaoEstoque.id }}</v-card-title
      >
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" variant="flat" @click="confirmarDelete"
          >OK</v-btn
        >
        <v-btn color="primary" variant="outlined" @click="dialogDelete = false"
          >Cancel</v-btn
        >
        <v-spacer></v-spacer>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import movimentacaoEstoqueService from '@/services/movimentacao-estoque-service';
import produtoService from '@/services/produto-service';
import { COLUNAS_TABELA_MOVIMENTACAO } from '@/constants/constants';
import MovimentacaoEstoque from '@/models/movimentacao-estoque-model';
import Produto from '@/models/produto-model';
import formatador from '@/util/formatador.js';

export default {
  data: () => ({
    menu: false,
    abrirModal: false,
    movimentacaoEstoque: new MovimentacaoEstoque(),
    movimentacoes: [],
    produtos: [],
    produtoSelecionado: new Produto(),
    quantidadeEstoqueProduto: '',
    dialogDelete: false,
    modoEdicao: false,
    search: '', // Entrada de busca do autocomplete
    loadingProdutos: false,
    headers: COLUNAS_TABELA_MOVIMENTACAO,
  }),

  methods: {
    obterMovimentacoes() {
      movimentacaoEstoqueService
        .obterTodos()
        .then((response) => {
          this.movimentacoes = response.data.map(
            (c) => new MovimentacaoEstoque(c)
          );
        })
        .catch((error) => console.log(error));
    },

    obterProdutos() {
      produtoService
        .obterTodos()
        .then((res) => {
          this.produtos = res.data.map((p) => new Produto(p));
        })
        .catch((error) => console.log(error));
    },

    novaMovimentacao() {
      this.movimentacaoEstoque = new MovimentacaoEstoque();
      this.quantidadeEstoqueProduto = '';
      this.modoEdicao = false;
    },

    editar(item) {
      this.movimentacaoEstoque = new MovimentacaoEstoque(item);
      this.movimentacaoEstoque.dataMovimentacao = this.formatarDataParaInput(
        item.dataMovimentacao
      );
      this.modoEdicao = true;
      this.abrirModal = true;
    },

    salvarNovo() {
      if (!this.movimentacaoEstoque.modeloValido()) {
        alert('Preencha todos os campos corretamente.');
        return;
      }
      const estoqueValido = this.movimentarEstoqueProduto();

      if (!estoqueValido) return;

      movimentacaoEstoqueService
        .criar(this.movimentacaoEstoque)
        .then(() => {
          produtoService
            .atualizar(this.produtoSelecionado.id, this.produtoSelecionado)
            .then((res) => console.log(res))
            .catch((err) => console.log(err));
          this.obterMovimentacoes();
          this.abrirModal = false;
        })
        .catch((error) => console.log(error));
    },

    salvarEdicao() {
      if (!this.movimentacaoEstoque.modeloValido()) {
        alert('Preencha todos os campos corretamente.');
        return;
      }

      this.movimentarEstoqueProduto();

      movimentacaoEstoqueService
        .atualizar(this.movimentacaoEstoque.id, this.movimentacaoEstoque)
        .then((response) => {
          console.log(response);
          this.obterMovimentacoes();
          this.abrirModal = false;
        })
        .catch((error) => console.log(error));
    },

    salvar() {
      this.modoEdicao ? this.salvarEdicao() : this.salvarNovo();
    },

    deletar(item) {
      this.movimentacaoEstoque = new MovimentacaoEstoque(item);
      this.dialogDelete = true;
    },

    confirmarDelete() {
      movimentacaoEstoqueService
        .deletar(this.movimentacaoEstoque.id)
        .then((_) => {
          this.obterMovimentacoes();
          this.movimentacaoEstoque = new MovimentacaoEstoque();
          this.dialogDelete = false;
        })
        .catch((error) => console.log(error));
    },

    dataFormatada(data) {
      return formatador.formatarData(data);
    },

    formatarDataParaInput(data) {
      if (!data) return '';
      const date = new Date(data);
      return date.toISOString().split('T')[0]; // Formato yyyy-MM-dd
    },

    getProdutoNome(idProduto) {
      const produto = this.produtos.find((p) => p.id === idProduto);
      return produto ? produto.nome : 'Produto não encontrado';
    },

    movimentarEstoqueProduto() {
      if (this.modoEdicao) {
        // Aqui você pode recalcular o estoque com base na diferença entre a movimentação antiga e a nova
        const quantidadeAnterior = this.movimentacoes.find(
          (m) => m.id === this.movimentacaoEstoque.id
        ).quantidade;

        if (this.movimentacaoEstoque.tipoMovimentacao === 'Saída') {
          this.produtoSelecionado.quantidadeEstoque += quantidadeAnterior; // desfaz a saída antiga
          this.produtoSelecionado.quantidadeEstoque -=
            this.movimentacaoEstoque.quantidade; // aplica a nova saída
        }

        if (this.movimentacaoEstoque.tipoMovimentacao === 'Entrada') {
          this.produtoSelecionado.quantidadeEstoque -= quantidadeAnterior; // desfaz a entrada antiga
          this.produtoSelecionado.quantidadeEstoque +=
            this.movimentacaoEstoque.quantidade; // aplica a nova entrada
        }
      }

      let quantidadeMovimentada = parseInt(this.movimentacaoEstoque.quantidade);

      if (this.movimentacaoEstoque.tipoMovimentacao === 'Saída') {
        if (this.produtoSelecionado.quantidadeEstoque < quantidadeMovimentada) {
          alert('Quantidade de saída maior que o estoque disponível!');
          return; // Não prossegue com a movimentação
        }
        this.produtoSelecionado.quantidadeEstoque -= quantidadeMovimentada;
      }

      if (this.movimentacaoEstoque.tipoMovimentacao === 'Entrada') {
        this.produtoSelecionado.quantidadeEstoque += quantidadeMovimentada;
      }
    },
  },

  watch: {
    'movimentacaoEstoque.idProduto'(idProdutoSelecionado) {
      const produto = this.produtos.find((p) => p.id === idProdutoSelecionado);
      this.produtoSelecionado = new Produto(produto);

      if (produto) {
        this.quantidadeEstoqueProduto = produto.quantidadeEstoque;
      } else {
        this.quantidadeEstoqueProduto = '';
      }
    },
  },

  created() {
    this.obterMovimentacoes();
    this.obterProdutos();
  },
};
</script>

<template>
  <v-data-table
    :headers="headers"
    :items="produtos"
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
              @click="novoProduto"
              v-bind="props"
            >
              Novo produto
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
                      v-model="produto.id"
                      disabled
                      label="ID"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="10" sm="10">
                    <v-text-field
                      v-model="produto.nome"
                      label="Nome"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="4" sm="12">
                    <v-text-field
                      v-model="produto.quantidadeEstoque"
                      label="Estoque"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="4" sm="12">
                    <v-text-field
                      v-model="produto.preco"
                      label="Preço"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="4" sm="12">
                    <v-select
                      v-model="produto.idCategoria"
                      :items="categorias"
                      item-title="nome"
                      item-value="id"
                      label="Categoria"
                    >
                    </v-select>
                  </v-col>
                  <v-col cols="12" md="12" sm="12">
                    <v-textarea
                      v-model="produto.descricao"
                      label="Descrição"
                    ></v-textarea>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="primary" variant="flat" @click="salvar">
                Salvar
              </v-btn>
              <v-btn color="primary" variant="outlined" @click="fecharModal">
                Cancelar
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:[`item.idCategoria`]="{ item }">
      <span>{{ getCategoriaNome(item.idCategoria) }}</span>
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
        >Deseja excluir o produto {{ produto.id }} -
        {{ produto.nome }}</v-card-title
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
import { COLUNAS_TABELA_PRODUTO } from '@/constants/constants';
import Categoria from '@/models/categoria-model';
import Produto from '@/models/produto-model';
import categoriaService from '@/services/categoria-service';
import produtoService from '@/services/produto-service';

export default {
  data: () => ({
    abrirModal: false,
    produto: new Produto(),
    categorias: [],
    produtos: [],
    dialogDelete: false,
    modoEdicao: false,
    headers: COLUNAS_TABELA_PRODUTO,
  }),

  methods: {
    fecharModal() {
      this.abrirModal = false;
    },

    obterProdutos() {
      produtoService
        .obterTodos()
        .then((res) => {
          this.produtos = res.data.map((p) => new Produto(p));
        })
        .catch((error) => console.log(error));
    },

    obterCategorias() {
      categoriaService
        .obterTodos()
        .then((res) => {
          this.categorias = res.data.map((c) => new Categoria(c));
          console.log(this.categorias);
        })
        .catch((error) => console.log(error));
    },

    novoProduto() {
      this.produto = new Produto();
      this.modoEdicao = false;
    },

    editar(item) {
      this.produto = new Produto(item);
      this.modoEdicao = true;
      this.abrirModal = true;
    },

    salvarEdicao() {
      if (!this.produto.modeloValido()) {
        return;
      }

      produtoService
        .atualizar(this.produto.id, this.produto)
        .then((res) => {
          console.log(res);
          this.obterProdutos();
          this.abrirModal = false;
        })
        .catch((err) => console.log(err));
    },

    salvarNovo() {
      if (!this.produto.modeloValido()) return;

      produtoService
        .criar(this.produto)
        .then((res) => {
          console.log(res);
          this.obterProdutos();
          this.abrirModal = false;
        })
        .catch((err) => console.log(err));
    },

    salvar() {
      this.modoEdicao ? this.salvarEdicao() : this.salvarNovo();
    },

    deletar(item) {
      this.produto = new Produto(item);
      this.dialogDelete = true;
    },

    confirmarDelete() {
      produtoService
        .deletar(this.produto.id)
        .then(() => {
          this.obterProdutos();
          this.produto = new Produto();
          this.dialogDelete = false;
        })
        .catch((err) => console.log(err));
    },

    getCategoriaNome(idCategoria) {
      const categoria = this.categorias.find((c) => c.id === idCategoria);
      return categoria ? categoria.nome : 'Categoria não encontrada';
    },
  },

  computed: {},

  created() {
    this.obterProdutos();
    this.obterCategorias();
  },
};
</script>

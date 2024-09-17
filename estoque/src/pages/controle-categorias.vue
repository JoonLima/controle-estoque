<template>
  <v-data-table
    :headers="headers"
    :items="categorias"
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
              @click="novaCategoria"
              v-bind="props"
            >
              Nova categoria
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
                      v-model="categoria.id"
                      disabled
                      label="ID"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="10" sm="10">
                    <v-text-field
                      v-model="categoria.nome"
                      label="Nome"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="12" sm="12">
                    <v-text-field
                      v-model="categoria.descricao"
                      label="Descrição"
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
        >Deseja excluir a categoria {{ categoria.id }} -
        {{ categoria.nome }}</v-card-title
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
import Categoria from '@/models/categoria-model';
import categoriaService from '@/services/categoria-service';
import { COLUNAS_TABELA_CATEGORIA } from '@/constants/constants';

export default {
  data: () => ({
    abrirModal: false,
    categoria: new Categoria(),
    categorias: [],
    dialogDelete: false,
    modoEdicao: false,
    headers: COLUNAS_TABELA_CATEGORIA,
  }),

  methods: {
    obterCategorias() {
      categoriaService
        .obterTodos()
        .then((response) => {
          this.categorias = response.data.map((c) => new Categoria(c));
        })
        .catch((error) => console.log(error));
    },

    novaCategoria() {
      this.categoria = new Categoria();
      this.modoEdicao = false;
    },

    editar(item) {
      this.categoria = new Categoria(item);
      this.modoEdicao = true;
      this.abrirModal = true;
    },

    salvarNovo() {
      if (!this.categoria.modeloValido()) {
        this.snackbar = true;
        return;
      }

      categoriaService
        .criar(this.categoria)
        .then((response) => {
          console.log(response);
          this.obterCategorias();
          this.abrirModal = false;
        })
        .catch((error) => console.log(error));
    },

    salvarEdicao() {
      if (!this.categoria.modeloValido()) return;

      categoriaService
        .atualizar(this.categoria.id, this.categoria)
        .then((response) => {
          console.log(response);
          this.obterCategorias();
          this.abrirModal = false;
        })
        .catch((error) => console.log(error));
    },

    salvar() {
      this.modoEdicao ? this.salvarEdicao() : this.salvarNovo();
    },

    deletar(item) {
      this.categoria = new Categoria(item);
      this.dialogDelete = true;
    },

    confirmarDelete() {
      categoriaService
        .deletar(this.categoria.id)
        .then((_) => {
          this.obterCategorias();
          this.categoria = new Categoria();
          this.dialogDelete = false;
        })
        .catch((error) => console.log(error));
    },
  },

  created() {
    this.obterCategorias();
  },
};
</script>

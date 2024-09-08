<template>
  <v-dialog v-model="abrirModal" max-width="60%">
    <template v-slot:activator="{ props }">
      <v-btn class="mb-2" color="primary" dark v-bind="props">
        <v-icon>mdi-plus</v-icon>
        {{ tituloBotao }}
      </v-btn>
    </template>
    <v-card>
      <slot></slot>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue-darken-1" variant="text" @click="fecharModal">
          Salvar
        </v-btn>
        <v-btn color="blue-darken-1" variant="text" @click="fecharModal">
          Cancelar
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: {
    tituloBotao: { type: String, required: true, default: '' },
  },

  methods: {
    fecharModal() {
      this.abrirModal = false;
    },
  },

  data() {
    return {
      abrirModal: false,
    };
  },
};
</script>

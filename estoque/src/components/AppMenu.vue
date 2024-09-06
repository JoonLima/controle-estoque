<template>
  <div class="menu">
    <span class="titulo">Controle de estoque</span>
    <div class="opcoes-menu">
      <router-link>Produtos</router-link>
      <router-link>Categorias</router-link>
      <router-link>Movimentações</router-link>
      <v-switch :onchange="alterarTema" hide-details inset></v-switch>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AppMenu',
  data() {
    return {};
  },

  methods: {
    alterarTema() {
      this.$vuetify.theme.global.name = this.$vuetify.theme.global.current.dark
        ? 'light'
        : 'dark';
    },
  },
};
</script>

<style lang="scss" scoped>
.menu {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 15px;
  background-color: #00609c;

  .titulo {
    font-size: 21px;
    font-weight: 500;
    letter-spacing: 2px;
    color: #fff;
  }

  .opcoes-menu {
    display: flex;
    align-items: center;
    gap: 5px;

    a {
      text-decoration: none;
      color: #fff;
      cursor: pointer;
      padding: 0 5px;
      margin: 0 15px;
      transition: 0.4s;
    }

    a:hover {
      color: #bebebe;
      border-bottom: 1px solid #bebebe;
    }
  }
}
</style>

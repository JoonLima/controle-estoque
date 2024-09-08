<template>
  <div class="menu">
    <router-link to="/" class="titulo">Controle de estoque</router-link>
    <div class="opcoes-menu">
      <router-link to="/">Dashboard</router-link>
      <router-link to="/controle-produtos">Produtos</router-link>
      <router-link to="controle-categorias">Categorias</router-link>
      <router-link to="controle-movimentacao">Movimentações</router-link>
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
  padding: 0 1.5rem;
  background-color: #00609c;

  .titulo {
    font-size: 21px;
    font-weight: 500;
    letter-spacing: 2px;
    color: #fff;
    text-decoration: none;
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

<template>
  <v-app>
    <v-main>
      <app-menu></app-menu>
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
import AppMenu from './components/AppMenu.vue';

export default {
  component: { AppMenu },
};
</script>

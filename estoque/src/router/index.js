import { createRouter, createWebHistory } from 'vue-router/auto';
// import { routes } from 'vue-router/auto-routes'

import controleDashboard from '@/pages/controle-dashboard.vue';
import controleProdutos from '@/pages/controle-produtos.vue';
import controleCategorias from '@/pages/controle-categorias.vue';
import controleMovimentacao from '@/pages/controle-movimentacao.vue';

const routes = [
  {
    path: '/',
    name: 'controleDashboard',
    component: controleDashboard,
  },
  {
    path: '/controle-produtos',
    name: 'controleProdutos',
    component: controleProdutos,
  },
  {
    path: '/controle-categorias',
    name: 'controleCategorias',
    component: controleCategorias,
  },
  {
    path: '/controle-movimentacao',
    name: 'controleMovimentacao',
    component: controleMovimentacao,
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

// Workaround for https://github.com/vitejs/vite/issues/11804
router.onError((err, to) => {
  if (err?.message?.includes?.('Failed to fetch dynamically imported module')) {
    if (!localStorage.getItem('vuetify:dynamic-reload')) {
      console.log('Reloading page to fix dynamic import error');
      localStorage.setItem('vuetify:dynamic-reload', 'true');
      location.assign(to.fullPath);
    } else {
      console.error('Dynamic import error, reloading page did not fix it', err);
    }
  } else {
    console.error(err);
  }
});

router.isReady().then(() => {
  localStorage.removeItem('vuetify:dynamic-reload');
});

export default router;

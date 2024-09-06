/**
 * plugins/vuetify.js
 *
 * Framework documentation: https://vuetifyjs.com`
 */

// Styles
import '@mdi/font/css/materialdesignicons.css';
import 'vuetify/styles';

// Composables
import { createVuetify } from 'vuetify';

// https://vuetifyjs.com/en/introduction/why-vuetify/#feature-guides
export default createVuetify({
  theme: {
    defaultTheme: 'dark', // Tema padrão
    themes: {
      light: {
        colors: {
          primary: '#00609C', // Cor primária para o tema claro
          background: '#f5f5f5',
        },
      },
      dark: {
        colors: {
          primary: '#00609C',
          background: '#121212',
        },
      },
    },
  },
});

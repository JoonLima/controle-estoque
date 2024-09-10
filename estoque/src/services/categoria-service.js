import http from './api';

function obterTodos() {
  return new Promise((resolve, reject) => {
    return http
      .get('/categoria')
      .then((res) => resolve(res))
      .catch((error) => reject(error));
  });
}

function obterPorId(id) {
  return http
    .get(`/categoria/${id}`)
    .then((res) => res)
    .catch((error) => {
      throw error;
    });
}

export default {
  obterTodos,
  obterPorId,
};

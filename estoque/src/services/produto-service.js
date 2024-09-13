import http from './api';

function obterTodos() {
  return new Promise((resolve, reject) => {
    return http
      .get('/produto')
      .then((response) => resolve(response))
      .catch((error) => reject(error));
  });
}

function obterPorId(id) {
  return new Promise((resolve, reject) => {
    return http
      .get(`/produto/${id}`)
      .then((response) => resolve(response))
      .catch((error) => reject(error));
  });
}

function criar(produto) {
  return new Promise((resolve, reject) => {
    return http
      .post('/produto', produto)
      .then((response) => resolve(response))
      .catch((error) => reject(error));
  });
}

function atualizar(id, produto) {
  return new Promise((resolve, reject) => {
    return http
      .put(`/produto/${id}`, produto)
      .then((response) => resolve(response))
      .catch((error) => reject(error));
  });
}

function deletar(id) {
  return new Promise((resolve, reject) => {
    return http
      .delete(`/produto/${id}`)
      .then((response) => resolve(response))
      .catch((error) => reject(error));
  });
}

export default {
  obterTodos,
  obterPorId,
  criar,
  atualizar,
  deletar,
};

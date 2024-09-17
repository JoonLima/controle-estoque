import http from './api';

function obterTodos() {
  return new Promise((resolve, reject) => {
    return http
      .get('/movimentacao-estoque')
      .then((response) => resolve(response))
      .catch((error) => reject(error));
  });
}

function obterPorId(id) {
  return new Promise((resolve, reject) => {
    return http
      .get(`/movimentacao-estoque/${id}`)
      .then((response) => resolve(response))
      .catch((error) => reject(error));
  });
}

function criar(movimentacao) {
  return new Promise((resolve, reject) => {
    return http
      .post('/movimentacao-estoque', movimentacao)
      .then((response) => resolve(response))
      .catch((error) => reject(error));
  });
}

function atualizar(id, movimentacao) {
  return new Promise((resolve, reject) => {
    return http
      .put(`/movimentacao-estoque/${id}`, movimentacao)
      .then((response) => resolve(response))
      .catch((error) => reject(error));
  });
}

function deletar(id) {
  return new Promise((resolve, reject) => {
    return http
      .delete(`/movimentacao-estoque/${id}`)
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

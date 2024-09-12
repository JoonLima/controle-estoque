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
  return new Promise((resolve, reject) => {
    return http
      .get(`/categoria/${id}`)
      .then((res) => resolve(res))
      .catch((error) => reject(error));
  });
}

function criar(categoria) {
  return new Promisse((resolve, reject) => {
    return http
      .post('/categoria', categoria)
      .then((res) => resolve(res))
      .catch((error) => reject(error));
  });
}

function atualizar(id, categoria) {
  return new Promise((resolve, reject) => {
    return http
      .put(`/categoria/${id}`, categoria)
      .then((res) => resolve(res))
      .catch((error) => reject(error));
  });
}

function deletar(id) {
  return new Promise((resolve, reject) => {
    return http
      .delete(`/categoria/${id}`)
      .then((res) => resolve(res))
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

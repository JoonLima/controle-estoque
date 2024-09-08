import axios from 'axios';

const http = axios.create({
  baseURL: 'http://localhost:5018',
});

export default http;

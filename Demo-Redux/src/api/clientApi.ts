import axios from 'axios';

export const clientApi = axios.create({
  baseURL: 'https://localhost:7152/api',
});

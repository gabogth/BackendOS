import { environmentBase } from '@environment/environment.base';

export const environment = {
  ...environmentBase,
  production: true,
  envName: 'production',
  apiBaseUrl: 'https://api.tu-dominio.com',
};

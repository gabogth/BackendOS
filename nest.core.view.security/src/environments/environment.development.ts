import { environmentBase } from '@environment/environment.base';

export const environment = {
  ...environmentBase,
  production: false,
  envName: 'development',
  apiBaseUrl: 'http://localhost:5128',
};

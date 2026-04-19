import { Routes } from '@angular/router';

import { MainPageComponent } from './features/main/pages/main-page.component';

export const appRoutes: Routes = [
  {
    path: '',
    component: MainPageComponent,
    title: 'Index',
  },
  {
    path: '**',
    redirectTo: '',
  },
];

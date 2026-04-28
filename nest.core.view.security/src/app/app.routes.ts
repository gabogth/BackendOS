import { Routes } from '@angular/router';
import { authGuard } from './core/auth/auth.guard';
import { ShellComponent } from './layout/shell/shell.component';
import { LoginPageComponent } from './features/auth/pages/login-page.component';
import { MainPageComponent } from './features/main/pages/main-page.component';
import { UsuariosPageComponent } from './features/usuarios/pages/usuarios-page.component';

export const appRoutes: Routes = [
  {
    path: 'login',
    component: LoginPageComponent,
    title: 'Login',
  },
  {
    path: '',
    component: ShellComponent,
    canActivate: [authGuard],
    children: [
      {
        path: '',
        component: MainPageComponent,
        title: 'Index',
      },
      {
        path: 'usuarios',
        component: UsuariosPageComponent,
        title: 'Usuarios',
      },
    ],
  },
  {
    path: '**',
    redirectTo: '',
  },
];

import { Routes } from '@angular/router';
import { authGuard } from './core/auth/auth.guard';
import { LoginPageComponent } from './features/auth/pages/login-page.component';
import { MainPageComponent } from './features/main/pages/main-page.component';
import { RolesPageComponent } from './features/roles/pages/roles-page.component';
import { UsuariosPageComponent } from './features/usuarios/pages/usuarios-page.component';
import { FormulariosPageComponent } from './features/formularios/pages/formularios-page.component';
import { MasterComponent } from './layout/master/master.component';
import { RoleClaimPageComponent } from './features/role-claim/pages/role-claim-page.component';

export const appRoutes: Routes = [
  {
    path: 'login',
    component: LoginPageComponent,
    title: 'Login',
  },
  {
    path: '',
    component: MasterComponent,
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
      {
        path: 'roles',
        component: RolesPageComponent,
        title: 'Roles',
      },
      {
        path: 'formularios',
        component: FormulariosPageComponent,
        title: 'Formularios',
      },
      {
        path: 'role-claim',
        component: RoleClaimPageComponent,
        title: 'Role Claim',
      },
    ],
  },
  {
    path: '**',
    redirectTo: '',
  },
];

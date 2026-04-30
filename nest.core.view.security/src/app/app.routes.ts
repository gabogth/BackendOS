import { Routes } from '@angular/router';
import { authGuard } from './core/auth/auth.guard';
import { LoginPageComponent } from './features/auth/pages/login-page.component';
import { MainPageComponent } from './features/main/pages/main-page.component';
import { RolesPageComponent } from './features/roles/pages/roles-page.component';
import { UsuariosPageComponent } from './features/usuarios/pages/usuarios-page.component';
import { FormulariosPageComponent } from './features/formularios/pages/formularios-page.component';
import { MasterComponent } from './layout/master/master.component';
import { RoleClaimPageComponent } from './features/role-claim/pages/role-claim-page.component';
import { RoleUserPageComponent } from './features/role-user/pages/role-user-page.component';
import { claimGuard } from './core/auth/claim.guard';

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
        canActivate: [claimGuard('aplicacion-home')]
      },
      {
        path: 'Index',
        component: MainPageComponent,
        title: 'Index',
        canActivate: [claimGuard('aplicacion-home')]
      },
      {
        path: 'mantenimiento/usuario',
        component: UsuariosPageComponent,
        title: 'Usuarios',
        canActivate: [claimGuard('seguridad-usuario')]
      },
      {
        path: 'seguridad/rol',
        component: RolesPageComponent,
        title: 'Roles',
        canActivate: [claimGuard('seguridad-rol')]
      },
      {
        path: 'seguridad/menu',
        component: FormulariosPageComponent,
        title: 'Formularios',
        canActivate: [claimGuard('seguridad-menu')]
      },
      {
        path: 'seguridad/rolMenu',
        component: RoleClaimPageComponent,
        title: 'Role Claim',
        canActivate: [claimGuard('seguridad-rolMenu')]
      },
      {
        path: 'seguridad/rolUsuario',
        component: RoleUserPageComponent,
        title: 'Role Usuario',
        canActivate: [claimGuard('seguridad-rolUsuario')]
      },
    ],
  },
  {
    path: '**',
    redirectTo: '',
  },
];

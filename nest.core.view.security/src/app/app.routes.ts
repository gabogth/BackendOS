import { Routes } from '@angular/router';
import { authGuard } from './core/auth/auth.guard';
import { LoginPageComponent } from './features/seguridad/auth/pages/login-page.component';
import { AccessDeniedPageComponent } from './layout/access-denied/access-denied-page.component';
import { MainPageComponent } from './layout/main/pages/main-page.component';
import { RolesPageComponent } from './features/seguridad/roles/pages/roles-page.component';
import { UsuariosPageComponent } from './features/seguridad/usuarios/pages/usuarios-page.component';
import { FormulariosPageComponent } from './features/seguridad/formularios/pages/formularios-page.component';
import { MasterComponent } from './layout/master/master.component';
import { RoleClaimPageComponent } from './features/seguridad/role-claim/pages/role-claim-page.component';
import { RoleUserPageComponent } from './features/seguridad/role-user/pages/role-user-page.component';
import { ModulosPageComponent } from './features/seguridad/modulos/pages/modulos-page.component';
import { claimGuard } from './core/auth/claim.guard';
import { AlmacenesPageComponent } from './features/logistica/almacenes/pages/almacenes-page.component';

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
        title: 'Nest',
        canActivate: [claimGuard('aplicacion-home')]
      },
      {
        path: 'Index',
        component: MainPageComponent,
        title: 'Nest',
        canActivate: [claimGuard('aplicacion-home')]
      },
      {
        path: 'mantenimiento/usuario',
        component: UsuariosPageComponent,
        title: 'Nest | Usuarios',
        canActivate: [claimGuard('seguridad-usuario')]
      },
      {
        path: 'seguridad/rol',
        component: RolesPageComponent,
        title: 'Nest | Roles',
        canActivate: [claimGuard('seguridad-rol')]
      },
      {
        path: 'seguridad/menu',
        component: FormulariosPageComponent,
        title: 'Nest | Formularios',
        canActivate: [claimGuard('seguridad-menu')]
      },
      {
        path: 'seguridad/modulo',
        component: ModulosPageComponent,
        title: 'Nest | Módulos',
        canActivate: [claimGuard('seguridad-modulo')]
      },
      {
        path: 'seguridad/rolMenu',
        component: RoleClaimPageComponent,
        title: 'Nest | Role Claim',
        canActivate: [claimGuard('seguridad-rolMenu')]
      },
      {
        path: 'seguridad/rolUsuario',
        component: RoleUserPageComponent,
        title: 'Nest | Role Usuario',
        canActivate: [claimGuard('seguridad-rolUsuario')]
      },

      {
        path: 'logistica/almacen',
        component: AlmacenesPageComponent,
        title: 'Nest | Almacenes',
        canActivate: [claimGuard('logistica-almacen')]
      },
      {
        path: 'acceso-denegado',
        component: AccessDeniedPageComponent,
        title: 'Nest | Acceso denegado',
      },
    ],
  },
  {
    path: '**',
    redirectTo: '',
  },
];

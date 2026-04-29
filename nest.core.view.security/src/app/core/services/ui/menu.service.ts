import { Injectable } from '@angular/core';
import { MenuItem } from '@app/layout/models/menu-item.model';

@Injectable({
  providedIn: 'root',
})
export class MenuService {
  getMenu(): MenuItem[] {
    return [
      {
        label: 'Administración',
        icon: 'fa-solid fa-screwdriver-wrench',
        children: [
          {
            label: 'Usuarios',
            icon: 'fa-solid fa-users',
            route: '/usuarios',
          },
          {
            label: 'Roles',
            icon: 'fa-solid fa-user-shield',
            route: '/roles',
          },
          {
            label: 'Formularios',
            icon: 'fa-solid fa-file-lines',
            route: '/formularios',
          },
          {
            label: 'Role Claim',
            icon: 'fa-solid fa-diagram-project',
            route: '/role-claim',
          },
        ],
      },
      {
        label: 'Seguridad',
        icon: 'fa-solid fa-shield-halved',
        children: [
          {
            label: 'Auditoría',
            icon: 'fa-solid fa-clipboard-check',
            route: '/',
          },
          {
            label: 'Bitácora',
            icon: 'fa-solid fa-book',
            route: '/',
          },
        ],
      },
      {
        label: 'Reportes',
        icon: 'fa-solid fa-chart-column',
        route: '/',
      },
    ];
  }
}

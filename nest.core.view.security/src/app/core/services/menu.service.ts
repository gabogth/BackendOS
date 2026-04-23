import { Injectable } from '@angular/core';

import { MenuItem } from '../layout/models/menu-item.model';

@Injectable({
  providedIn: 'root',
})
export class MenuService {
  getMenu(): MenuItem[] {
    return [
      {
        label: 'Administración',
        children: [
          {
            label: 'Usuarios',
            route: '/usuarios',
          },
          {
            label: 'Roles',
            route: '/',
          },
        ],
      },
      {
        label: 'Seguridad',
        children: [
          {
            label: 'Auditoría',
            route: '/',
          },
          {
            label: 'Bitácora',
            route: '/',
          },
        ],
      },
      {
        label: 'Reportes',
        route: '/',
      },
    ];
  }
}

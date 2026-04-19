import { Injectable } from '@angular/core';

import { UserEntity } from '../entities/user.entity';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  getCurrentUser(): UserEntity {
    return {
      id: 1,
      username: 'admin',
      displayName: 'Administrador Demo',
      email: 'admin@demo.local',
    };
  }
}

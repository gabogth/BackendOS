import { Injectable, Signal, inject } from '@angular/core';

import { AuthService } from '../auth/auth.service';
import { UserEntity } from '../entities/user.entity';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly authService = inject(AuthService);

  getCurrentUser(): Signal<UserEntity | null> {
    return this.authService.currentUser;
  }
}

import { Injectable, inject } from '@angular/core';
import { AuthService } from '../seguridad/security/auth.service';

@Injectable({
  providedIn: 'root',
})
export class UserSessionService {
  private readonly authService = inject(AuthService);
  currentUser = this.authService.currentUser;
  empresaId = this.authService.currentUser()!.empresaId;
}

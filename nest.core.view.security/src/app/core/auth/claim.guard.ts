import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '@app/core/services/security/auth.service';

export const claimGuard = (claimName: string): CanActivateFn => {
  return () => {
    const authService = inject(AuthService);
    const router = inject(Router);
    return authService.hasClaim(claimName) ? true : router.parseUrl('/acceso-denegado');
  };
};
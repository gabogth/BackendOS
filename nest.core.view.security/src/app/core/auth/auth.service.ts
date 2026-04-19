import { HttpClient } from '@angular/common/http';
import { Injectable, computed, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map, of, tap } from 'rxjs';

import { UserEntity } from '../entities/user.entity';
import { AuthResponse } from './models/auth-response.model';
import { LoginRequest } from './models/login-request.model';

const ACCESS_TOKEN_KEY = 'security.access_token';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly httpClient = inject(HttpClient);
  private readonly router = inject(Router);

  private readonly accessToken = signal<string | null>(localStorage.getItem(ACCESS_TOKEN_KEY));

  readonly isAuthenticated = computed(() => Boolean(this.accessToken()));
  readonly currentUser = computed<UserEntity | null>(() => this.mapUserFromToken(this.accessToken()));

  login(request: LoginRequest) {
    return this.httpClient.post<AuthResponse>('/Auth/login', request).pipe(
      tap((response) => this.setAccessToken(response.accessToken)),
      map(() => true),
      catchError(() => of(false)),
    );
  }

  logout(): void {
    this.setAccessToken(null);
    void this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return this.accessToken();
  }

  private setAccessToken(token: string | null): void {
    this.accessToken.set(token);

    if (token) {
      localStorage.setItem(ACCESS_TOKEN_KEY, token);
      return;
    }

    localStorage.removeItem(ACCESS_TOKEN_KEY);
  }

  private mapUserFromToken(token: string | null): UserEntity | null {
    if (!token) {
      return null;
    }

    const payload = this.decodeTokenPayload(token);
    if (!payload) {
      return null;
    }

    const email = this.getStringClaim(payload, ['email', 'upn']);
    const username = this.getStringClaim(payload, ['preferred_username', 'unique_name']) ?? email;
    const displayName = this.getStringClaim(payload, ['name', 'given_name']) ?? username ?? 'Usuario';
    const id = Number(this.getStringClaim(payload, ['nameid', 'sub']) ?? 0);

    return {
      id: Number.isNaN(id) ? 0 : id,
      username: username ?? 'usuario',
      displayName,
      email: email ?? 'no-email',
    };
  }

  private decodeTokenPayload(token: string): Record<string, unknown> | null {
    const segments = token.split('.');

    if (segments.length < 2) {
      return null;
    }

    try {
      const base64 = segments[1].replace(/-/g, '+').replace(/_/g, '/');
      const json = decodeURIComponent(
        atob(base64)
          .split('')
          .map((char) => `%${`00${char.charCodeAt(0).toString(16)}`.slice(-2)}`)
          .join(''),
      );

      return JSON.parse(json) as Record<string, unknown>;
    } catch {
      return null;
    }
  }

  private getStringClaim(payload: Record<string, unknown>, claimNames: string[]): string | null {
    for (const claimName of claimNames) {
      const claimValue = payload[claimName];

      if (typeof claimValue === 'string' && claimValue.trim().length) {
        return claimValue;
      }
    }

    return null;
  }
}

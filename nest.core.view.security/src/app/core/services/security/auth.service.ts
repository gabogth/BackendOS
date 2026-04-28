import { HttpClient } from '@angular/common/http';
import { Injectable, computed, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable, tap } from 'rxjs';
import { UserEntity } from '@app/core/entities/user.entity';
import { AuthResponse } from '@app/core/auth/models/auth-response.model';
import { LoginRequest } from '@app/core/auth/models/login-request.model';
import { environment } from '@environment/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly httpClient = inject(HttpClient);
  private readonly router = inject(Router);

  private readonly accessToken = signal<string | null>(localStorage.getItem(environment.accessTokenKey));
  private readonly accessTokenData = signal<string | null>(localStorage.getItem(environment.accessTokenDataKey));

  readonly isAuthenticated = computed(() => Boolean(this.accessToken()));
  readonly currentUser = computed<UserEntity | null>(() => this.mapUserFromToken(this.accessToken()));

  login(request: LoginRequest): Observable<boolean> {
    const requestUrl = `${environment.apiBaseUrl}/security/Auth/login`;
    const result = this.httpClient.post<AuthResponse>(requestUrl, request).pipe(
      tap((response) => { 
        this.setAccessToken(response.accessToken);
        this.setTokenData(JSON.stringify(response));
      }),
      map((data) => true),
    );
    return result;
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
      localStorage.setItem(environment.accessTokenKey, token);
    } else {
      localStorage.removeItem(environment.accessTokenKey);
    }
  }

  private setTokenData(token: any): void {
    this.accessTokenData.set(token);
    if (token) {
      localStorage.setItem(environment.accessTokenDataKey, token);
    } else {
      localStorage.removeItem(environment.accessTokenDataKey);
    }
  }

  private mapUserFromToken(token: string | null): UserEntity | null {
    if (!token) {
      return null;
    }

    const payload = this.decodeTokenPayload(token);
    if (!payload) {
      return null;
    }

    const userId = this.getStringClaim(payload, [environment.accessTokenUserIdKey]);
    const userName = this.getStringClaim(payload, [environment.accessTokenUserKey]);
    const empresaId = parseInt(this.getStringClaim(payload, [environment.accessTokenEmpresaIdKey]) ?? '0');

    return {
      userId: userId ?? '0',
      userName: userName ?? '',
      empresaId: empresaId
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

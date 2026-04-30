import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '@environment/environment';

@Injectable({ providedIn: 'root' })
export class RoleUserService {
  private readonly httpClient = inject(HttpClient);
  private readonly endpoint = `${environment.apiBaseUrl}/security/RolUsuario`;

  merge(roleName: string, usersId: string[]): Observable<boolean> {
    return this.httpClient.post<boolean>(`${this.endpoint}/${encodeURIComponent(roleName)}`, usersId);
  }
}

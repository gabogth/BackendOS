import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

import { SecurityUserCreatePayload, SecurityUserEntity, SecurityUserUpdatePayload } from '../entities/security-user.entity';
import { environment } from '@environment/environment';

@Injectable({
  providedIn: 'root',
})
export class SecurityUserService {
  private readonly httpClient = inject(HttpClient);
  private readonly endpoint = `${environment.apiBaseUrl}/security/Usuario`;

  getAll(): Observable<SecurityUserEntity[]> {
    return this.httpClient.get<SecurityUserEntity[]>(this.endpoint);
  }

  getById(id: string): Observable<SecurityUserEntity> {
    return this.httpClient.get<SecurityUserEntity>(`${this.endpoint}/${id}`);
  }

  create(payload: SecurityUserCreatePayload): Observable<SecurityUserEntity> {
    return this.httpClient.post<SecurityUserEntity>(this.endpoint, payload);
  }

  update(payload: SecurityUserUpdatePayload): Observable<SecurityUserEntity> {
    return this.httpClient.put<SecurityUserEntity>(`${this.endpoint}/${payload.id}`, payload);
  }

  delete(id: string): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.endpoint}/${id}`);
  }
}

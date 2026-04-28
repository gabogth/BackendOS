import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

import {
  SecurityRoleCreatePayload,
  SecurityRoleEntity,
  SecurityRoleUpdatePayload,
} from '@app/core/entities/security-role.entity';
import { environment } from '@environment/environment';

@Injectable({
  providedIn: 'root',
})
export class SecurityRoleService {
  private readonly httpClient = inject(HttpClient);
  private readonly endpoint = `${environment.apiBaseUrl}/security/Rol`;

  getAll(): Observable<SecurityRoleEntity[]> {
    return this.httpClient.get<SecurityRoleEntity[]>(this.endpoint);
  }

  getByFilter(loadOptions: LoadOptions): Observable<LoadResult<SecurityRoleEntity[]>> {
    return this.httpClient.post<LoadResult<SecurityRoleEntity[]>>(`${this.endpoint}/filter`, loadOptions);
  }

  getById(id: string): Observable<SecurityRoleEntity> {
    return this.httpClient.get<SecurityRoleEntity>(`${this.endpoint}/${id}`);
  }

  create(payload: SecurityRoleCreatePayload): Observable<SecurityRoleEntity> {
    return this.httpClient.post<SecurityRoleEntity>(this.endpoint, payload);
  }

  update(payload: SecurityRoleUpdatePayload): Observable<SecurityRoleEntity> {
    return this.httpClient.put<SecurityRoleEntity>(`${this.endpoint}/${payload.id}`, payload);
  }

  delete(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.endpoint}/${id}`);
  }
}

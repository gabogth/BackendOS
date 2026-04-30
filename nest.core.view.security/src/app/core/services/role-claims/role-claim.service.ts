import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

import { ClaimEntity } from '@app/core/entities/claim.entity';
import { environment } from '@environment/environment';

@Injectable({ providedIn: 'root' })
export class RoleClaimService {
  private readonly httpClient = inject(HttpClient);
  private readonly endpoint = `${environment.apiBaseUrl}/security/RolClaim`;

  merge(roleId: string, claims: ClaimEntity[]): Observable<boolean> {
    return this.httpClient.post<boolean>(`${this.endpoint}/${roleId}`, claims);
  }
}

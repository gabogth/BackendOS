import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadOptions, LoadResult } from 'devextreme/common/data';
import { environment } from '@environment/environment';
import { FormularioCreatePayload, FormularioEntity, FormularioUpdatePayload } from '@app/core/entities/formulario.entity';

@Injectable({ providedIn: 'root' })
export class FormularioService {
  private readonly httpClient = inject(HttpClient);
  private readonly endpoint = `${environment.apiBaseUrl}/security/Formulario`;

  getByFilter(loadOptions: LoadOptions): Observable<LoadResult<FormularioEntity[]>> {
    return this.httpClient.post<LoadResult<FormularioEntity[]>>(`${this.endpoint}/filter`, loadOptions);
  }

  getByAll(): Observable<FormularioEntity[]> {
    return this.httpClient.get<FormularioEntity[]>(`${this.endpoint}`);
  }

  getById(id: number): Observable<FormularioEntity> {
    return this.httpClient.get<FormularioEntity>(`${this.endpoint}/${id}`);
  }

  getByRoleId(roleId: string): Observable<FormularioEntity[]> {
    return this.httpClient.get<FormularioEntity[]>(`${this.endpoint}/rol/${roleId}`);
  }

  create(payload: FormularioCreatePayload): Observable<FormularioEntity> {
    return this.httpClient.post<FormularioEntity>(this.endpoint, payload);
  }

  update(payload: FormularioUpdatePayload): Observable<FormularioEntity> {
    return this.httpClient.put<FormularioEntity>(`${this.endpoint}/${payload.id}`, payload);
  }

  delete(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.endpoint}/${id}`);
  }
}

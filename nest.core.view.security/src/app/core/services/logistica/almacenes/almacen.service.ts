import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

import { AlmacenCreatePayload, AlmacenEntity, AlmacenUpdatePayload } from '@app/core/entities/almacen.entity';
import { environment } from '@environment/environment';

@Injectable({
  providedIn: 'root',
})
export class AlmacenService {
  private readonly httpClient = inject(HttpClient);
  private readonly endpoint = `${environment.apiBaseUrl}/logistica/Almacen`;

  getByFilter(loadOptions: LoadOptions): Observable<LoadResult<AlmacenEntity[]>> {
    return this.httpClient.post<LoadResult<AlmacenEntity[]>>(`${this.endpoint}/filter`, loadOptions);
  }

  getByFilterActivos(loadOptions: LoadOptions): Observable<LoadResult<AlmacenEntity[]>> {
    return this.httpClient.post<LoadResult<AlmacenEntity[]>>(`${this.endpoint}/filter_activos`, loadOptions);
  }

  getById(id: number): Observable<AlmacenEntity> {
    return this.httpClient.get<AlmacenEntity>(`${this.endpoint}/${id}`);
  }

  create(payload: AlmacenCreatePayload): Observable<AlmacenEntity> {
    return this.httpClient.post<AlmacenEntity>(this.endpoint, payload);
  }

  update(payload: AlmacenUpdatePayload): Observable<AlmacenEntity> {
    return this.httpClient.put<AlmacenEntity>(`${this.endpoint}/${payload.id}`, payload);
  }

  delete(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.endpoint}/${id}`);
  }
}

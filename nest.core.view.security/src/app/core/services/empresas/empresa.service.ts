import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

import { EmpresaEntity } from '@app/core/entities/empresa.entity';
import { environment } from '@environment/environment';

@Injectable({
  providedIn: 'root',
})
export class EmpresaService {
  private readonly httpClient = inject(HttpClient);
  private readonly endpoint = `${environment.apiBaseUrl}/corporativo/Empresa`;

  getById(id: number): Observable<EmpresaEntity> {
    return this.httpClient.get<EmpresaEntity>(`${this.endpoint}/${id}`);
  }

  getActivosByFilter(loadOptions: LoadOptions): Observable<LoadResult<EmpresaEntity[]> | EmpresaEntity[]> {
    return this.httpClient.request<LoadResult<EmpresaEntity[]> | EmpresaEntity[]>('GET', `${this.endpoint}/filter_activos`, {
      body: loadOptions,
    });
  }
}

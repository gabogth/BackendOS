import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadOptions, LoadResult } from 'devextreme/common/data';
import { environment } from '@environment/environment';
import { ModuloEntity } from '@app/core/entities/modulo.entity';

@Injectable({ providedIn: 'root' })
export class ModuloService {
  private readonly httpClient = inject(HttpClient);
  private readonly endpoint = `${environment.apiBaseUrl}/security/Modulo`;

  getByFilter(loadOptions: LoadOptions): Observable<LoadResult<ModuloEntity[]>> {
    return this.httpClient.post<LoadResult<ModuloEntity[]>>(`${this.endpoint}/filter`, loadOptions);
  }

  getActivosByFilter(loadOptions: LoadOptions): Observable<LoadResult<ModuloEntity[]>> {
    return this.httpClient.post<LoadResult<ModuloEntity[]>>(`${this.endpoint}/filter_activos`, loadOptions);
  }

  getById(id: number): Observable<ModuloEntity> {
    return this.httpClient.get<ModuloEntity>(`${this.endpoint}/${id}`);
  }
}

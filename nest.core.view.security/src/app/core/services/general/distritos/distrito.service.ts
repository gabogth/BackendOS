import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

import { DistritoEntity } from '@app/core/entities/distrito.entity';
import { environment } from '@environment/environment';

@Injectable({
  providedIn: 'root',
})
export class DistritoService {
  private readonly httpClient = inject(HttpClient);
  private readonly endpoint = `${environment.apiBaseUrl}/general/Distrito`;

  getByFilterActivos(loadOptions: LoadOptions): Observable<LoadResult<DistritoEntity[]>> {
    return this.httpClient.post<LoadResult<DistritoEntity[]>>(`${this.endpoint}/filter_activos`, loadOptions);
  }
}

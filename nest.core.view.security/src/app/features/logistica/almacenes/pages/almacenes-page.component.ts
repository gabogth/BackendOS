import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxDataGridModule } from 'devextreme-angular';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

import { AlmacenCreatePayload, AlmacenEntity } from '@app/core/entities/almacen.entity';
import { AlmacenService } from '@app/core/services/logistica/almacenes/almacen.service';
import { NestUtils } from '@app/core/services/util/nestUtils';

@Component({
  selector: 'app-almacenes-page',
  imports: [DxDataGridModule],
  templateUrl: './almacenes-page.component.html',
  styleUrl: './almacenes-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AlmacenesPageComponent {
  private readonly almacenService = inject(AlmacenService);

  protected readonly almacenesDataSource = new CustomStore<AlmacenEntity, number>({
    key: 'id',
    useDefaultSearch: true,
    load: async (options: LoadOptions): Promise<LoadResult<AlmacenEntity[]>> => {
      try {
        return await firstValueFrom(this.almacenService.getByFilter(options));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    byKey: async (key: number): Promise<AlmacenEntity> => {
      return firstValueFrom(this.almacenService.getById(Number(key)));
    },
    insert: async (values: Partial<AlmacenEntity>): Promise<AlmacenEntity> => {
      const payload: AlmacenCreatePayload = {
        nombre: values.nombre?.trim() ?? '',
        nombreCorto: values.nombreCorto?.trim() ?? '',
        distritoId: Number(values.distritoId),
        direccion: values.direccion?.trim() ?? '',
        latitud: Number(values.latitud ?? 0),
        lonitud: Number(values.longitud ?? 0),
        activo: values.activo ?? true,
      };

      return await firstValueFrom(this.almacenService.create(payload));
    },
    update: async (key: number, values: Partial<AlmacenEntity>): Promise<AlmacenEntity> => {
      const current = await firstValueFrom(this.almacenService.getById(Number(key)));
      return await firstValueFrom(
        this.almacenService.update({
          id: Number(key),
          nombre: values.nombre?.trim() ?? current.nombre,
          nombreCorto: values.nombreCorto?.trim() ?? current.nombreCorto,
          distritoId: values.distritoId ?? current.distritoId,
          direccion: values.direccion?.trim() ?? current.direccion,
          latitud: values.latitud ?? current.latitud,
          lonitud: values.longitud ?? current.longitud,
          activo: values.activo ?? current.activo,
        }),
      );
    },
    remove: async (key: number): Promise<void> => {
      await firstValueFrom(this.almacenService.delete(Number(key)));
    },
  });
}

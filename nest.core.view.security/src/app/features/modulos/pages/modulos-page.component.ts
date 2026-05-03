import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxDataGridModule } from 'devextreme-angular';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

import { ModuloCreatePayload, ModuloEntity } from '@app/core/entities/modulo.entity';
import { ModuloService } from '@app/core/services/modulos/modulo.service';
import { NestUtils } from '@app/core/services/util/nestUtils';

@Component({
  selector: 'app-modulos-page',
  imports: [DxDataGridModule],
  templateUrl: './modulos-page.component.html',
  styleUrl: './modulos-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ModulosPageComponent {
  private readonly moduloService = inject(ModuloService);

  protected readonly modulosDataSource = new CustomStore<ModuloEntity, number>({
    key: 'id',
    useDefaultSearch: true,
    load: async (options: LoadOptions): Promise<LoadResult<ModuloEntity[]>> => {
      try {
        return await firstValueFrom(this.moduloService.getByFilter(options));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    byKey: async (key: number): Promise<ModuloEntity> => {
      return firstValueFrom(this.moduloService.getById(Number(key)));
    },
    insert: async (values: Partial<ModuloEntity>): Promise<ModuloEntity> => {
      return await firstValueFrom(this.moduloService.create(values as ModuloCreatePayload));
    },
    update: async (key: number, values: Partial<ModuloEntity>): Promise<ModuloEntity> => {
      const current = await firstValueFrom(this.moduloService.getById(Number(key)));
      return await firstValueFrom(
        this.moduloService.update({
          id: Number(key),
          nombre: values.nombre?.trim() ?? current.nombre,
          nombreCorto: values.nombreCorto?.trim() ?? current.nombreCorto,
          descripcion: values.descripcion?.trim() ?? current.descripcion,
          rutaImagen: values.rutaImagen?.trim() ?? current.rutaImagen,
          action: values.action?.trim() ?? current.action,
          controlador: values.controlador?.trim() ?? current.controlador,
          estado: values.estado ?? current.estado,
        }),
      );
    },
    remove: async (key: number): Promise<void> => {
      await firstValueFrom(this.moduloService.delete(Number(key)));
    },
  });
}

import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxDataGridModule } from 'devextreme-angular';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

import { ModuloCreatePayload, ModuloEntity } from '@app/core/entities/modulo.entity';
import { ModuloService } from '@app/core/services/seguridad/modulos/modulo.service';
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
      try {
        return await firstValueFrom(this.moduloService.create(values as ModuloCreatePayload));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    update: async (key: number, values: Partial<ModuloEntity>): Promise<ModuloEntity> => {
      try {
        const current = await firstValueFrom(this.moduloService.getById(Number(key)));
        return await firstValueFrom(
          this.moduloService.update({
            ...current, 
            ...values
          }),
        );
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    remove: async (key: number): Promise<void> => {
      try {
        await firstValueFrom(this.moduloService.delete(Number(key)));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
  });
}

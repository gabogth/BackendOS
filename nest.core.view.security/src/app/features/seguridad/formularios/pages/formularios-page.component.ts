import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxTreeListModule } from 'devextreme-angular';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

import { FormularioEntity } from '@app/core/entities/formulario.entity';
import { ModuloEntity } from '@app/core/entities/modulo.entity';
import { FormularioService } from '@app/core/services/seguridad/formularios/formulario.service';
import { ModuloService } from '@app/core/services/seguridad/modulos/modulo.service';
import { NestUtils } from '@app/core/services/util/nestUtils';

@Component({
  selector: 'app-formularios-page',
  imports: [DxTreeListModule],
  templateUrl: './formularios-page.component.html',
  styleUrl: './formularios-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FormulariosPageComponent {
  private readonly formularioService = inject(FormularioService);
  private readonly moduloService = inject(ModuloService);

  protected readonly modulosDataSource = new CustomStore<ModuloEntity, number>({
    key: 'id',
    load: async (options: LoadOptions): Promise<LoadResult<ModuloEntity[]>> => firstValueFrom(this.moduloService.getActivosByFilter(options)),
    byKey: async (key: number): Promise<ModuloEntity> => firstValueFrom(this.moduloService.getById(Number(key))),
  });

  protected readonly formulariosDataSource = new CustomStore<FormularioEntity, number>({
    key: 'id',
    load: async (options: LoadOptions): Promise<LoadResult<FormularioEntity[]>> => {
      try {
        return await firstValueFrom(this.formularioService.getByFilter(options));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    byKey: async (key: number): Promise<FormularioEntity> => firstValueFrom(this.formularioService.getById(Number(key))),
    insert: async (values: Partial<FormularioEntity>): Promise<FormularioEntity> => firstValueFrom(this.formularioService.create(values as any)),
    update: async (key: number, values: Partial<FormularioEntity>): Promise<FormularioEntity> => {
      const current = await firstValueFrom(this.formularioService.getById(Number(key)));
      return firstValueFrom(this.formularioService.update({ ...current, ...values, id: Number(key) }));
    },
    remove: async (key: number): Promise<void> => {
      await firstValueFrom(this.formularioService.delete(Number(key)));
    },
  });
}

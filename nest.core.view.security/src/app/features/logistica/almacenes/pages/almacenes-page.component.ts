import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxDataGridModule } from 'devextreme-angular';
import { LoadOptions, LoadResult } from 'devextreme/common/data';
import { AlmacenCreatePayload, AlmacenEntity, AlmacenUpdatePayload } from '@app/core/entities/almacen.entity';
import { DistritoEntity } from '@app/core/entities/distrito.entity';
import { DistritoService } from '@app/core/services/general/distritos/distrito.service';
import { AlmacenService } from '@app/core/services/logistica/almacenes/almacen.service';
import { NestUtils } from '@app/core/services/util/nestUtils';
import { UserSessionService } from '@app/core/services/ui/user-session.service';

@Component({
  selector: 'app-almacenes-page',
  imports: [DxDataGridModule],
  templateUrl: './almacenes-page.component.html',
  styleUrl: './almacenes-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AlmacenesPageComponent {
  private readonly almacenService = inject(AlmacenService);
  private readonly distritoService = inject(DistritoService);
  private readonly sessionService = inject(UserSessionService);

  protected readonly distritosDataSource = new CustomStore<DistritoEntity, number>({
    key: 'id',
    useDefaultSearch: true,
    load: async (options: LoadOptions): Promise<LoadResult<DistritoEntity[]>> => {
      try {
        return await firstValueFrom(this.distritoService.getByFilterActivos(options));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    byKey: async (key: number): Promise<DistritoEntity> => {
      return await firstValueFrom(this.distritoService.getById(key));
    },
  });
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
      return await firstValueFrom(this.almacenService.getById(key));
    },
    insert: async (values: Partial<AlmacenEntity>): Promise<AlmacenEntity> => {
      try {
        return await firstValueFrom(this.almacenService.create({ 
          ...values, 
          empresaId: this.sessionService.currentUser()!.empresaId 
        } as AlmacenCreatePayload));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    update: async (key: number, values: Partial<AlmacenEntity>): Promise<AlmacenEntity> => {
      try {
        const current = await firstValueFrom(this.almacenService.getById(key));
        return await firstValueFrom(this.almacenService.update({ 
          ...current, 
          ...values
        } as AlmacenUpdatePayload));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    remove: async (key: number): Promise<void> => {
      try {
        await firstValueFrom(this.almacenService.delete(key));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
  });
}

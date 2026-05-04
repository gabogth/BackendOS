import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxDataGridModule } from 'devextreme-angular';
import { CustomStoreOptions, DataSource, DataSourceOptions, LoadOptions, LoadResult } from 'devextreme/common/data';

import { SecurityRoleCreatePayload, SecurityRoleEntity } from '@app/core/entities/security-role.entity';
import { SecurityRoleService } from '@app/core/services/seguridad/roles/security-role.service';
import { UserSessionService } from '@app/core/services/ui/user-session.service';
import { NestUtils } from '@app/core/services/util/nestUtils';
import { ɵInternalFormsSharedModule } from '@angular/forms';
import { EmpresaEntity } from '@app/core/entities/empresa.entity';
import { EmpresaService } from '@app/core/services/seguridad/empresas/empresa.service';
import { DxSelectBoxTypes } from 'devextreme-angular/ui/select-box';

@Component({
  selector: 'app-roles-page',
  imports: [DxDataGridModule, ɵInternalFormsSharedModule],
  templateUrl: './roles-page.component.html',
  styleUrl: './roles-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RolesPageComponent {
  private readonly securityRoleService = inject(SecurityRoleService);
  private readonly empresaService = inject(EmpresaService);
  private readonly userService = inject(UserSessionService);
  protected readonly empresaId = this.userService.empresaId;
  
  protected readonly empresasDataSource = new CustomStore<EmpresaEntity, number>({
    key: 'id',
    useDefaultSearch: true,
    load: async (options: LoadOptions): Promise<LoadResult<EmpresaEntity[]>> => {
      try {
        return await firstValueFrom(this.empresaService.getActivosByFilter(options));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    byKey: async (key: number): Promise<EmpresaEntity> => {
      return await firstValueFrom(this.empresaService.getById(Number(key)));
    },
  });

  protected readonly empresasDsWrapper: DataSourceOptions<EmpresaEntity, number> = {
    store: this.empresasDataSource,
    paginate: true,
    pageSize: 10,
  };

  protected readonly rolesDataSource = new CustomStore<SecurityRoleEntity, string>({
    key: 'id',
    useDefaultSearch: true,
    load: async (options: LoadOptions): Promise<LoadResult<SecurityRoleEntity[]>> => {
      try {
        return await firstValueFrom(this.securityRoleService.getByFilter(options));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    byKey: async (key: string): Promise<SecurityRoleEntity> => {
      return firstValueFrom(this.securityRoleService.getById(key));
    },
    insert: async (values: Partial<SecurityRoleEntity>): Promise<SecurityRoleEntity> => {
      values.empresaId = values.empresaId ? Number(values.empresaId) : this.empresaId;
      try {
        return await firstValueFrom(this.securityRoleService.create(values as SecurityRoleCreatePayload));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    update: async (key: string, values: Partial<SecurityRoleEntity>): Promise<SecurityRoleEntity> => {
      const current = await firstValueFrom(this.securityRoleService.getById(key));
      return await firstValueFrom(
        this.securityRoleService.update({
          id: Number(key),
          name: values.name?.trim() ?? current.name,
        }),
      );
    },
    remove: async (key: string): Promise<void> => {
      await firstValueFrom(this.securityRoleService.delete(Number(key)));
    },
  });
}

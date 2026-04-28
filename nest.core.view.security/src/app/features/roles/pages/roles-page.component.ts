import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxDataGridModule } from 'devextreme-angular';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

import { SecurityRoleCreatePayload, SecurityRoleEntity } from '@app/core/entities/security-role.entity';
import { SecurityRoleService } from '@app/core/services/roles/security-role.service';
import { UserSessionService } from '@app/core/services/ui/user-session.service';
import { NestUtils } from '@app/core/services/util/nestUtils';
import { ɵInternalFormsSharedModule } from "@angular/forms";

@Component({
  selector: 'app-roles-page',
  imports: [DxDataGridModule, ɵInternalFormsSharedModule],
  templateUrl: './roles-page.component.html',
  styleUrl: './roles-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RolesPageComponent {
  private readonly securityRoleService = inject(SecurityRoleService);
  private readonly userService = inject(UserSessionService);
  protected readonly empresaId = this.userService.empresaId;

  protected readonly rolesDataSource = new CustomStore<SecurityRoleEntity, string>({
    key: 'id',
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
      values.empresaId = this.empresaId;
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

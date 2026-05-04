import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxButtonModule, DxDataGridModule } from 'devextreme-angular';
import { LoadOptions, LoadResult } from 'devextreme/common/data';
import notify from 'devextreme/ui/notify';
import { DxDataGridTypes } from 'devextreme-angular/ui/data-grid';

import { SecurityRoleEntity } from '@app/core/entities/security-role.entity';
import { SecurityUserEntity } from '@app/core/entities/security-user.entity';
import { SecurityRoleService } from '@app/core/services/seguridad/roles/security-role.service';
import { SecurityUserService } from '@app/core/services/seguridad/users/security-user.service';
import { RoleUserService } from '@app/core/services/seguridad/role-users/role-user.service';
import { NestUtils } from '@app/core/services/util/nestUtils';

@Component({
  selector: 'app-role-user-page',
  imports: [DxButtonModule, DxDataGridModule],
  templateUrl: './role-user-page.component.html',
  styleUrl: './role-user-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RoleUserPageComponent {
  private readonly securityRoleService = inject(SecurityRoleService);
  private readonly securityUserService = inject(SecurityUserService);
  private readonly roleUserService = inject(RoleUserService);

  protected readonly selectedRoleId = signal<string | null>(null);
  protected readonly selectedUserIds = signal<string[]>([]);

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
  });

  protected readonly usersDataSource = new CustomStore<SecurityUserEntity, string>({
    key: 'id',
    useDefaultSearch: true,
    load: async (options: LoadOptions): Promise<LoadResult<SecurityUserEntity[]>> => {
      try {
        return await firstValueFrom(this.securityUserService.getByFilter(options));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
  });

  protected async onRoleSelectionChanged(event: DxDataGridTypes.SelectionChangedEvent<SecurityRoleEntity>) {
    const role = event.selectedRowsData[0];
    this.selectedRoleId.set(role?.id ?? null);
    await this.loadTreeForRole(role.name);
  }

  private async loadTreeForRole(roleName: string) {
    const result = await firstValueFrom(this.securityUserService.getByRoleName(roleName));
    const selectedUsers = result.map((f) => f.id);
    this.selectedUserIds.set(selectedUsers);
  }

  protected onUsersSelectionChanged(event: DxDataGridTypes.SelectionChangedEvent<SecurityUserEntity>) {
    this.selectedUserIds.set(event.selectedRowKeys as string[]);
  }

  protected async saveRoleUsers() {
    const roleId = this.selectedRoleId();
    if (!roleId) {
      notify('Seleccione un rol.', 'warning', 2500);
      return;
    }

    await NestUtils.showConfirmationDialog({
      title: 'Advertencia',
      text: '¿Estás seguro que desea guardar los usuarios asociados a este rol?',
      funtionToExecute: () => this.roleUserService.merge(roleId, this.selectedUserIds()),
    });
  }
}

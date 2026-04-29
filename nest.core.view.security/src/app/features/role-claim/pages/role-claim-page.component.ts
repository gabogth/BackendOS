import { ChangeDetectionStrategy, Component, inject, signal, ViewChild } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxButtonModule, DxDataGridComponent, DxDataGridModule, DxTreeViewComponent, DxTreeViewModule } from 'devextreme-angular';
import { LoadOptions, LoadResult } from 'devextreme/common/data';
import notify from 'devextreme/ui/notify';

import { ClaimEntity } from '@app/core/entities/claim.entity';
import { FormularioEntity } from '@app/core/entities/formulario.entity';
import { SecurityRoleEntity } from '@app/core/entities/security-role.entity';
import { FormularioService } from '@app/core/services/formularios/formulario.service';
import { RoleClaimService } from '@app/core/services/role-claims/role-claim.service';
import { SecurityRoleService } from '@app/core/services/roles/security-role.service';
import { NestUtils } from '@app/core/services/util/nestUtils';
import { DxDataGridTypes } from 'devextreme-angular/ui/data-grid';

@Component({
  selector: 'app-role-claim-page',
  imports: [DxButtonModule, DxDataGridModule, DxTreeViewModule],
  templateUrl: './role-claim-page.component.html',
  styleUrl: './role-claim-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RoleClaimPageComponent {
  private readonly securityRoleService = inject(SecurityRoleService);
  private readonly formularioService = inject(FormularioService);
  private readonly roleClaimService = inject(RoleClaimService);

  @ViewChild(DxTreeViewComponent) treeView?: DxTreeViewComponent;
  @ViewChild(DxDataGridComponent) roleGrid?: DxDataGridComponent;

  protected readonly selectedRoleId = signal<string | null>(null);
  protected readonly treeItems = signal<FormularioEntity[]>([]);

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

  protected async onRoleSelectionChanged(event: DxDataGridTypes.SelectionChangedEvent<SecurityRoleEntity>) {
    const role = event.selectedRowsData[0];
    if (!role?.id) {
      this.selectedRoleId.set(null);
      this.treeItems.set([]);
      return;
    }

    this.selectedRoleId.set(role.id.toString());
    await this.loadTreeForRole(role.id.toString());
  }

  protected async saveClaims() {
    const roleId = this.selectedRoleId();
    if (!roleId) {
      notify('Seleccione un rol.', 'warning', 2500);
      return;
    }

    const selectedIds = (this.treeView?.instance.getSelectedNodeKeys() ?? []) as number[];
    const selectedLeafNodes = this.treeItems().filter((node) => selectedIds.includes(node.id) && node.parentId !== null && node.parentId !== 0);

    const claims: ClaimEntity[] = selectedLeafNodes.map((node) => ({
      type: node.claimType,
      value: 'true',
    }));

    try {
      await firstValueFrom(this.roleClaimService.merge(roleId, claims));
      notify('Claims guardados correctamente.', 'success', 2500);
    } catch (e: any) {
      throw NestUtils.formatValidationErrors(e);
    }
  }

  private async loadTreeForRole(roleId: string) {
    const [allForms, formsByRole] = await Promise.all([
      firstValueFrom(this.formularioService.getByFilter({ take: 5000 } as LoadOptions)).then((res) => (res.data ?? []) as FormularioEntity[]),
      firstValueFrom(this.formularioService.getByRoleId(roleId)),
    ]);

    const selectedClaims = new Set(formsByRole.map((form) => form.claimType));
    const next = allForms.map((form) => ({ ...form, selected: selectedClaims.has(form.claimType) }));
    this.treeItems.set(next);
    queueMicrotask(() => {
      this.treeView?.instance.unselectAll();
      next.filter((x) => x.selected).forEach((x) => this.treeView?.instance.selectItem(x.id));
    });
  }
}

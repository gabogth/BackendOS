import { ChangeDetectionStrategy, Component, inject, OnInit, signal, ViewChild } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxButtonModule, DxDataGridComponent, DxDataGridModule, DxTreeViewComponent, DxTreeListComponent } from 'devextreme-angular';
import { LoadOptions, LoadResult } from 'devextreme/common/data';
import notify from 'devextreme/ui/notify';

import { ClaimEntity } from '@app/core/entities/claim.entity';
import { FormularioEntity } from '@app/core/entities/formulario.entity';
import { SecurityRoleEntity } from '@app/core/entities/security-role.entity';
import { FormularioService } from '@app/core/services/seguridad/formularios/formulario.service';
import { RoleClaimService } from '@app/core/services/seguridad/role-claims/role-claim.service';
import { SecurityRoleService } from '@app/core/services/seguridad/roles/security-role.service';
import { NestUtils } from '@app/core/services/util/nestUtils';
import { DxDataGridTypes } from 'devextreme-angular/ui/data-grid';
import { ModuloService } from '@app/core/services/seguridad/modulos/modulo.service';
import { ModuloEntity } from '@app/core/entities/modulo.entity';
import { DxTreeListTypes } from 'devextreme-angular/ui/tree-list';

@Component({
  selector: 'app-role-claim-page',
  imports: [DxButtonModule, DxDataGridModule, DxTreeListComponent],
  templateUrl: './role-claim-page.component.html',
  styleUrl: './role-claim-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RoleClaimPageComponent implements OnInit {
  @ViewChild(DxTreeViewComponent) treeView?: DxTreeViewComponent;
  @ViewChild(DxDataGridComponent) roleGrid?: DxDataGridComponent;

  private readonly securityRoleService = inject(SecurityRoleService);
  private readonly formularioService = inject(FormularioService);
  private readonly roleClaimService = inject(RoleClaimService);
  private readonly moduloService = inject(ModuloService);

  protected readonly selectedRoleId = signal<string | null>(null);
  protected readonly formularios = signal<FormularioEntity[]>([]);
  protected readonly selectedIds = signal<number[]>([]);

  protected readonly modulosDataSource = new CustomStore<ModuloEntity, number>({
    key: 'id',
    load: async (options: LoadOptions): Promise<LoadResult<ModuloEntity[]>> => firstValueFrom(this.moduloService.getActivosByFilter(options)),
    byKey: async (key: number): Promise<ModuloEntity> => firstValueFrom(this.moduloService.getById(Number(key))),
  });

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

  ngOnInit(): void {
    this.loadFormularios();
  }

  protected async loadFormularios() {
    const formularios = await firstValueFrom(this.formularioService.getByAll());
    this.formularios.set(formularios);
  }

  protected async onRoleSelectionChanged(event: DxDataGridTypes.SelectionChangedEvent<SecurityRoleEntity>) {
    const role = event.selectedRowsData[0];
    if (!role?.id) {
      this.selectedRoleId.set(null);
      return;
    }
    this.selectedRoleId.set(role.id);
    await this.loadTreeForRole(role.id);
  }

  protected async saveClaims() {
    const roleId = this.selectedRoleId();
    if (!roleId) {
      notify('Seleccione un rol.', 'warning', 2500);
      return;
    }
    try {
      const claims = await this.getSelectedClaims();
      await NestUtils.showConfirmationDialog({
        title: `Advertencia`,
        text: '¿Estás seguro que desea guardar los cambios de este rol?',
        funtionToExecute: () => this.roleClaimService.merge(roleId, claims)
      });
    } catch (e: any) {
      throw NestUtils.formatValidationErrors(e);
    }
  }

  protected async onFormsSelectionChanged(event: DxTreeListTypes.SelectionChangedEvent<FormularioEntity>){
    this.selectedIds.set([...event.selectedRowKeys]);
  }

  private async loadTreeForRole(roleId: string) {
    const result = await firstValueFrom(this.formularioService.getByRoleId(roleId));
    const selectedClaims = result.map((f) => f.id);
    console.log('Claims asociados al rol:', selectedClaims);
    this.selectedIds.set(selectedClaims);
  }

  private getSelectedClaims(): ClaimEntity[] {
    const dict = Object.fromEntries(
      this.formularios().map(item => [item.id, item])
    );
    return this.selectedIds().map((id) => {
      const form = dict[id];
      return {
        type: form.claimType,
        value: 'true'
      } as ClaimEntity;
    });
  }
}

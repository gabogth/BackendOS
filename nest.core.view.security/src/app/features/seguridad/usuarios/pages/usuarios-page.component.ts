import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { 
  DxDataGridModule, 
  DxTextBoxComponent, 
  DxButtonComponent, 
  DxPopupComponent, 
  DxValidatorComponent ,
  DxValidationGroupComponent
} from 'devextreme-angular';
import { SecurityUserCreatePayload, SecurityUserEntity, SecurityUserUpdatePayload } from '@app/core/entities/security-user.entity';
import { SecurityUserService } from '@app/core/services/seguridad/users/security-user.service';
import { NestUtils } from '@app/core/services/util/nestUtils';
import { DxDataGridTypes } from 'devextreme-angular/ui/data-grid';
import { LoadOptions, LoadResult } from 'devextreme/common/data';

@Component({
  selector: 'app-usuarios-page',
  imports: [
    DxDataGridModule, 
    DxPopupComponent, 
    DxTextBoxComponent, 
    DxButtonComponent, 
    DxValidatorComponent,
    DxValidationGroupComponent
  ],
  templateUrl: './usuarios-page.component.html',
  styleUrl: './usuarios-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UsuariosPageComponent {
  private readonly securityUserService = inject(SecurityUserService);
  protected detallesErrores: any = [];
  protected showPasswordPopup = signal(false);
  protected newPassword = '';
  protected confirmNewPassword = '';
  private selectedUser?: SecurityUserEntity;
  protected openPasswordPopup = () => this.showPasswordPopup.set(true);
  protected closePasswordPopup = () => this.showPasswordPopup.set(false);
  protected togglePasswordPopup = (value: boolean) => this.showPasswordPopup.set(value);

  protected readonly userDataSource = new CustomStore<SecurityUserEntity, string>({
    key: 'id',
    load: async (options: LoadOptions): Promise<LoadResult<SecurityUserEntity[]>> => {
      try {
        return await firstValueFrom(this.securityUserService.getByFilter(options));
      } catch (e: any) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    byKey: async (key: string): Promise<SecurityUserEntity> => {
      return firstValueFrom(this.securityUserService.getById(key));
    },
    insert: async (values: Partial<SecurityUserEntity>): Promise<SecurityUserEntity> => {
      try {
        return await firstValueFrom(this.securityUserService.create(values as SecurityUserCreatePayload));
      } catch (e) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    update: async (key: string, values: Partial<SecurityUserEntity>): Promise<SecurityUserEntity> => {
      try {
        const current = await firstValueFrom(this.securityUserService.getById(key));
        return await firstValueFrom(
          this.securityUserService.update({
            ...current,
            ...values,
            password: '',
          } as SecurityUserUpdatePayload),
        );
      } catch (e) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
    remove: async (key: string): Promise<void> => {
      try {
        await firstValueFrom(this.securityUserService.delete(key));
      } catch (e) {
        throw NestUtils.formatValidationErrors(e);
      }
    },
  });

  onEditorPreparing(e: DxDataGridTypes.EditorPreparingEvent<SecurityUserEntity>) {
    if (e.dataField === 'password') {
      e.editorOptions.visible = e.row?.isNewRow ? true : false;
    }
  }

  onChangePasswordClick = async (e: DxDataGridTypes.CellClickEvent<SecurityUserEntity>) => {
    const user = e.row?.data;
    this.selectedUser = user;
    this.newPassword = '';
    this.confirmNewPassword = '';
    this.openPasswordPopup();
  }

  async savePassword(validationGroup: DxValidationGroupComponent) {
    const resultValidate = validationGroup.instance.validate();
    if(!resultValidate.isValid){
      return;
    }
    
    await NestUtils.showConfirmationDialog({
      title: '¿Cambiar contraseña?',
      text: '¿Estás seguro de que deseas cambiar la contraseña de este usuario?',
      funtionToExecute: () => this.securityUserService.resetPw({
        id: this.selectedUser!.id,
        password: this.newPassword
      })
    });
    this.closePasswordPopup();
    this.newPassword = '';
    this.confirmNewPassword = '';
  }
}

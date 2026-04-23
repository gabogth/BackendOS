import { ChangeDetectionStrategy, Component, computed, inject, signal } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import CustomStore from 'devextreme/data/custom_store';
import { DxDataGridModule } from 'devextreme-angular';

import { SecurityUserEntity } from '@app/core/entities/security-user.entity';
import { SecurityUserService } from '@app/core/services/security-user.service';

@Component({
  selector: 'app-usuarios-page',
  imports: [DxDataGridModule],
  templateUrl: './usuarios-page.component.html',
  styleUrl: './usuarios-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UsuariosPageComponent {
  private readonly securityUserService = inject(SecurityUserService);

  protected readonly errorMessage = signal<string | null>(null);
  protected readonly users = signal<SecurityUserEntity[]>([]);
  protected readonly hasData = computed(() => this.users().length > 0);

  /**
   * DataSource de DevExpress con CRUD explícito.
   *
   * Métodos implementados:
   * - load: consulta al endpoint GET /security/Usuario.
   * - byKey: consulta GET /security/Usuario/{id}.
   * - insert: crea usuario con POST /security/Usuario.
   * - update: modifica usuario con PUT /security/Usuario/{id}.
   * - remove: elimina usuario con DELETE /security/Usuario/{id}.
   */
  protected readonly userDataSource = new CustomStore<SecurityUserEntity, string>({
    key: 'id',

    load: async (): Promise<SecurityUserEntity[]> => {
      try {
        const data = await firstValueFrom(this.securityUserService.getAll());
        this.users.set(data);
        this.errorMessage.set(null);
        return data;
      } catch {
        this.errorMessage.set('No se pudo cargar el listado de usuarios.');
        throw new Error('Error loading users');
      }
    },

    byKey: async (key: string): Promise<SecurityUserEntity> => {
      const row = this.users().find((item) => item.id === key);
      if (row) {
        return row;
      }

      return firstValueFrom(this.securityUserService.getById(key));
    },

    insert: async (values: Partial<SecurityUserEntity>): Promise<SecurityUserEntity> => {
      const email = values.email?.trim() ?? '';
      const password = values.passwordHash?.trim() ?? '';
      const phoneNumber = values.phoneNumber?.trim() ?? '';

      const created = await firstValueFrom(
        this.securityUserService.create({
          email,
          password,
          phoneNumber,
        }),
      );

      this.users.update((current) => [...current, created]);
      return created;
    },

    update: async (key: string, values: Partial<SecurityUserEntity>): Promise<SecurityUserEntity> => {
      const current = this.users().find((item) => item.id === key) ?? await firstValueFrom(this.securityUserService.getById(key));

      const updated = await firstValueFrom(
        this.securityUserService.update({
          id: key,
          email: values.email?.trim() ?? current.email,
          password: values.passwordHash?.trim() || current.passwordHash,
          phoneNumber: values.phoneNumber?.trim() ?? current.phoneNumber ?? '',
        }),
      );

      this.users.update((list) => list.map((item) => (item.id === key ? updated : item)));
      return updated;
    },

    remove: async (key: string): Promise<void> => {
      await firstValueFrom(this.securityUserService.delete(key));
      this.users.update((current) => current.filter((item) => item.id !== key));
    },
  });
}

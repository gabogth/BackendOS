import { inject, Injectable, signal } from '@angular/core';
import { FormularioService } from '../seguridad/formularios/formulario.service';
import { firstValueFrom } from 'rxjs';
import { MenuItem } from '@app/layout/models/menu-item.model';
import { FormularioEntity } from '@app/core/entities/formulario.entity';
import { environment } from '@environment/environment';
import { ModuloEntity } from '@app/core/entities/modulo.entity';
import { ICleanState } from '@app/core/interfaces/ICleanState';
import { StateService } from '../ui/state.service';

@Injectable({
  providedIn: 'root',
})
export class MenuService implements ICleanState{
  protected formulariosService = inject(FormularioService);
  protected stateRegistry = inject(StateService);

  public menuItems = signal<MenuItem[]>([]);
  public selectedModule = signal<ModuloEntity | null>(this.getSelectedModule());

  constructor() {
    this.stateRegistry.register(this);
  }

  public async loadMenu() {
    const menu = await this.getMenu();
    const filteredMenu = this.filterCurrentMenu(menu);
    this.setMenu(menu);
    this.menuItems.set(filteredMenu);
  }

  public async setSelectedModule(module: ModuloEntity) {
    this.selectedModule.set(module);
    if (module === null)
      localStorage.removeItem(environment.selectedModuleKey);
    else
      localStorage.setItem(environment.selectedModuleKey, JSON.stringify(module));
    await this.loadMenu();
  }

  private setMenu(items: MenuItem[]) {
    localStorage.setItem(environment.menuKey, JSON.stringify(items));
  }

  private async getMenu(): Promise<MenuItem[]> {
    const menu = localStorage.getItem(environment.menuKey);
    if (menu) {
      return JSON.parse(menu) as MenuItem[];
    } else{
      const formularios = await firstValueFrom(this.formulariosService.getByCurrentUser());
      return this.buildMenu(formularios);
    }
  }

  private filterCurrentMenu(menu: MenuItem[]): MenuItem[]{
    const selectedModule = this.getSelectedModule();
    const filteredMenu = selectedModule === null
      ? []
      : (menu ?? []).filter((form) => form.module === selectedModule.id);
    return filteredMenu;
  }

  private getSelectedModule(): ModuloEntity | null {
    const moduleString = localStorage.getItem(environment.selectedModuleKey);
    if (!moduleString) {
      return null;
    }
    return JSON.parse(moduleString) as ModuloEntity;
  }

  private buildMenu(items: FormularioEntity[]): MenuItem[] {
    const map = new Map<number, MenuItem & { id: number; parentId: number | null }>();
    items.forEach(item => {
      map.set(item.id, {
        id: item.id,
        parentId: item.parentId,
        label: item.nombre,
        icon: item.icono,
        module: item.moduloId,
        route: item.action || undefined,
        children: []
      });
    });
    const roots: MenuItem[] = [];
    map.forEach(node => {
      if (node.parentId === null) {
        roots.push(node);
      } else {
        const parent = map.get(node.parentId);
        if (parent) {
          parent.children = parent.children || [];
          parent.children.push(node);
        }
      }
    });
    this.clean(roots);
    return roots;
  }

  private clean = (nodes: MenuItem[]) => {
    nodes.forEach(n => {
      if (n.children && n.children.length === 0) {
        delete n.children;
      } else if (n.children) {
        this.clean(n.children);
      }
    });
  };

  cleanState(): void {
    this.menuItems.set([]);
    this.selectedModule.set(null);
  }
}

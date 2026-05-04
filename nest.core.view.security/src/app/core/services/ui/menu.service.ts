import { inject, Injectable, signal } from '@angular/core';
import { FormularioService } from '../formularios/formulario.service';
import { firstValueFrom } from 'rxjs';
import { MenuItem } from '@app/layout/models/menu-item.model';
import { FormularioEntity } from '@app/core/entities/formulario.entity';
import { environment } from '@environment/environment';

@Injectable({
  providedIn: 'root',
})
export class MenuService {
  protected formulariosService = inject(FormularioService);
  public menuItems = signal<MenuItem[]>([]);
  public selectedModuleId = signal<number | null>(this.getSelectedModuleId());

  public async loadMenu() {
    const menu = await this.getMenu();
    this.menuItems.set(menu);
  }

  public async setSelectedModule(moduleId: number | null) {
    this.selectedModuleId.set(moduleId);

    if (moduleId === null) {
      localStorage.removeItem(environment.selectedModuleKey);
    } else {
      localStorage.setItem(environment.selectedModuleKey, moduleId.toString());
    }

    localStorage.removeItem(environment.menuKey);
    await this.loadMenu();
  }

  public clearMenuCache() {
    localStorage.removeItem(environment.menuKey);
    localStorage.removeItem(environment.selectedModuleKey);
    this.menuItems.set([]);
    this.selectedModuleId.set(null);
  }

  private setMenu(items: MenuItem[]) {
    localStorage.setItem(environment.menuKey, JSON.stringify(items));
  }

  private async getMenu(): Promise<MenuItem[]> {
    const menu = localStorage.getItem(environment.menuKey);
    if (menu) {
      return JSON.parse(menu) as MenuItem[];
    }

    const formularios = await firstValueFrom(this.formulariosService.getByCurrentUser());
    const selectedModuleId = this.selectedModuleId();
    const filteredForms =
      selectedModuleId === null
        ? []
        : (formularios ?? []).filter((form) => form.moduloId === selectedModuleId);

    if (filteredForms.length > 0) {
      const menuBuild = this.buildMenu(filteredForms);
      this.setMenu(menuBuild);
      return menuBuild;
    }

    return [];
  }

  private getSelectedModuleId(): number | null {
    const moduleId = localStorage.getItem(environment.selectedModuleKey);
    if (!moduleId) {
      return null;
    }

    const parsedId = Number(moduleId);
    return Number.isNaN(parsedId) ? null : parsedId;
  }

  private buildMenu(items: FormularioEntity[]): MenuItem[] {
    const map = new Map<number, MenuItem & { id: number; parentId: number | null }>();
    items.forEach(item => {
      map.set(item.id, {
        id: item.id,
        parentId: item.parentId,
        label: item.nombre,
        icon: item.icono,
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
}

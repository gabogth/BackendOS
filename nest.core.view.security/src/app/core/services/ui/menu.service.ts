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

  public async loadMenu(){
    const menu = await this.getMenu();
    this.menuItems.set(menu);
  }

  setMenu(items: MenuItem[]){
    localStorage.setItem(environment.menuKey, JSON.stringify(items));
  }

  async getMenu() : Promise<MenuItem[]> {
    const menu = localStorage.getItem(environment.menuKey);
    if(menu)
      return JSON.parse(menu) as MenuItem[];
    else {
      const formularios = await firstValueFrom(this.formulariosService.getByCurrentUser());
      const newforms = (formularios && formularios.length > 0) ? formularios.filter(x => x.moduloId == 1) : [];
      if(newforms && newforms.length > 0) {
        const menuBuild = this.buildMenu(newforms);
        this.setMenu(menuBuild);
        return menuBuild;
      }
      return [];
    }
  }

  private buildMenu(items: FormularioEntity[]) : MenuItem[]{
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

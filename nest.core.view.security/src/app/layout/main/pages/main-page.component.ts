import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { UserSessionService } from '@app/core/services/ui/user-session.service';
import { ModuloService } from '@app/core/services/seguridad/modulos/modulo.service';
import { ModuloEntity } from '@app/core/entities/modulo.entity';
import { MenuService } from '@app/core/services/ui/menu.service';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
})
export class MainPageComponent implements OnInit {
  protected userService = inject(UserSessionService);
  protected moduloService = inject(ModuloService);
  protected currentUser = this.userService.currentUser();
  protected modulos = signal<ModuloEntity[]>([]);
  private readonly menuService = inject(MenuService);
  protected currentModule = this.menuService.selectedModule;

  ngOnInit(): void {
    this.loadModules();
  }

  async loadModules(){
    const modulosResult = await firstValueFrom(this.moduloService.getAll());
    this.modulos.set(modulosResult);
  }

  getImage(image: string){
    return `assets/images/${image}`;
  }

  async onModuleClick(modulo: ModuloEntity){
    await this.menuService.setSelectedModule(modulo);
  }
}

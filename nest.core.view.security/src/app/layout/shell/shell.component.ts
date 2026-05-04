import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NavComponent } from '../nav/nav.component';
import { UsernavComponent } from '../usernav/usernav.component';
import { MenuService } from '@app/core/services/ui/menu.service';

@Component({
  selector: 'app-shell',
  imports: [RouterLink, NavComponent, UsernavComponent],
  templateUrl: './shell.component.html',
  styleUrl: './shell.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent {
  private readonly menuService = inject(MenuService);
  protected currentModule = this.menuService.selectedModule;

  getImage(image: string){
    return `assets/images/${image}`;
  }
}

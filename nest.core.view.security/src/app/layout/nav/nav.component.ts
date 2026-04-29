import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { MenuService } from '@app/core/services/ui/menu.service';
import { MenuItem } from '../models/menu-item.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-nav',
  imports: [RouterLink],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavComponent {
  private readonly menuService = inject(MenuService);
  protected readonly menuItems = this.menuService.getMenu();

  protected trackByLabel(_index: number, item: MenuItem): string {
    return item.label;
  }
}

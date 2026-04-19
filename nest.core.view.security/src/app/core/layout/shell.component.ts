import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

import { AuthService } from '../auth/auth.service';
import { MenuService } from '../services/menu.service';
import { UserService } from '../services/user.service';
import { MenuItem } from './models/menu-item.model';

@Component({
  selector: 'app-shell',
  imports: [RouterLink, RouterOutlet],
  templateUrl: './shell.component.html',
  styleUrl: './shell.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent {
  private readonly menuService = inject(MenuService);
  private readonly userService = inject(UserService);
  private readonly authService = inject(AuthService);

  protected readonly menuItems = this.menuService.getMenu();
  protected readonly currentUser = this.userService.getCurrentUser();

  protected trackByLabel(_index: number, item: MenuItem): string {
    return item.label;
  }

  protected logout(): void {
    this.authService.logout();
  }
}

import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

import { AuthService } from '../../services/auth.service';
import { MenuService } from '../../services/menu.service';
import { ThemeMode, ThemeService } from '../../services/theme.service';
import { UserService } from '../../services/user.service';
import { MenuItem } from '../models/menu-item.model';

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
  private readonly themeService = inject(ThemeService);

  protected readonly menuItems = this.menuService.getMenu();
  protected readonly currentUser = this.userService.currentUser;
  protected readonly currentTheme = this.themeService.currentTheme;

  protected trackByLabel(_index: number, item: MenuItem): string {
    return item.label;
  }

  protected changeTheme(mode: ThemeMode): void {
    this.themeService.setTheme(mode);
  }

  protected logout(): void {
    this.authService.logout();
  }
}

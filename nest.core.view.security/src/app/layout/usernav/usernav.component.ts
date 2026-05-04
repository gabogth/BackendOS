import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { AuthService } from '@app/core/services/seguridad/security/auth.service';
import { ThemeMode, ThemeService } from '@app/core/services/ui/theme.service';
import { UserSessionService } from '@app/core/services/ui/user-session.service';

@Component({
  selector: 'app-usernav',
  imports: [],
  templateUrl: './usernav.component.html',
  styleUrl: './usernav.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  host: {
    'class': 'ms-auto align-items-lg-center gap-lg-2'
  }
})
export class UsernavComponent {
  private readonly userService = inject(UserSessionService);
  private readonly authService = inject(AuthService);
  private readonly themeService = inject(ThemeService);
  protected readonly currentUser = this.userService.currentUser;
  protected readonly currentTheme = this.themeService.currentTheme;

  protected changeTheme(mode: ThemeMode): void {
    this.themeService.setTheme(mode);
  }

  protected logout(): void {
    this.authService.logout();
  }
}

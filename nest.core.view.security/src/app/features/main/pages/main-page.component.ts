import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { UserSessionService } from '@app/core/services/ui/user-session.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MainPageComponent {
  userService = inject(UserSessionService);
  currentUser = this.userService.currentUser();
}

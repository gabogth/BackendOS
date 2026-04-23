import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { UserService } from '@app/core/services/user.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MainPageComponent {
  userService = inject(UserService);
  currentUser = this.userService.currentUser();
}

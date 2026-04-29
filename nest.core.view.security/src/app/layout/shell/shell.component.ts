import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NavComponent } from '../nav/nav.component';
import { UsernavComponent } from '../usernav/usernav.component';

@Component({
  selector: 'app-shell',
  imports: [RouterLink, NavComponent, UsernavComponent],
  templateUrl: './shell.component.html',
  styleUrl: './shell.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent {
  
}

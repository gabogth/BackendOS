import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ShellComponent } from '../shell/shell.component';
import { RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-master',
  imports: [ShellComponent, RouterOutlet],
  templateUrl: './master.component.html',
  styleUrl: './master.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MasterComponent {

}

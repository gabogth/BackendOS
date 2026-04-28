import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { ThemeService } from '../core/services/ui/theme.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit {
  private readonly themeService = inject(ThemeService);
  constructor() {}

  async ngOnInit(): Promise<void> {
    await this.themeService.initialize();
  }
}

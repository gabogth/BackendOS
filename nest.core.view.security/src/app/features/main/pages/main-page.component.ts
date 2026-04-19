import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-main-page',
  template: `
    <section class="text-center py-5">
      <h1 class="display-5 fw-bold">INDEX</h1>
    </section>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MainPageComponent {}

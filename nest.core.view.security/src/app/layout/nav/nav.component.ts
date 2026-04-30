import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { MenuItem } from '../models/menu-item.model';
import { RouterLink } from '@angular/router';
import { MenuService } from '@app/core/services/ui/menu.service';

@Component({
  selector: 'app-nav',
  imports: [RouterLink],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavComponent implements OnInit {
  private readonly menuService = inject(MenuService);
  protected menuItems = this.menuService.menuItems;

  ngOnInit(): void {
    this.menuService.loadMenu();
  }

  protected getIcon(icon: string){
    return `fa fa-${icon} me2`;
  }


  protected trackByLabel(_index: number, item: MenuItem): string {
    return item.label;
  }
}

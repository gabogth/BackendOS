import { DOCUMENT } from '@angular/common';
import { Injectable, inject, signal } from '@angular/core';

import themes from 'devextreme/ui/themes';

export type ThemeMode = 'light' | 'dark';

@Injectable({ providedIn: 'root' })
export class ThemeService {
  private static readonly STORAGE_KEY = 'ui.theme.mode';
  private static readonly DEVEXTREME_THEME_LINK_ID = 'devextreme-theme-link';

  private readonly document = inject(DOCUMENT);

  private readonly themeMap: Record<ThemeMode, { bootstrap: string; devextreme: string }> = {
    light: {
      bootstrap: 'light',
      devextreme: '/assets/devextreme/dx.light.compact.css',
    },
    dark: {
      bootstrap: 'dark',
      devextreme: '/assets/devextreme/dx.dark.compact.css',
    },
  };

  readonly currentTheme = signal<ThemeMode>('light');

  initialize(): void {
    const savedTheme = this.getStoredTheme();
    this.setTheme(savedTheme);
  }

  setTheme(mode: ThemeMode): void {
    this.currentTheme.set(mode);

    const selectedTheme = this.themeMap[mode];
    this.document.documentElement.setAttribute('data-bs-theme', selectedTheme.bootstrap);
    this.syncDevextremeThemeLink(selectedTheme.devextreme);
    themes.current(mode === 'dark' ? 'generic.dark.compact' : 'generic.light.compact');

    localStorage.setItem(ThemeService.STORAGE_KEY, mode);
  }

  toggleTheme(): void {
    this.setTheme(this.currentTheme() === 'light' ? 'dark' : 'light');
  }

  private getStoredTheme(): ThemeMode {
    const mode = localStorage.getItem(ThemeService.STORAGE_KEY);
    return mode === 'dark' ? 'dark' : 'light';
  }

  private syncDevextremeThemeLink(href: string): void {
    let themeLink = this.document.getElementById(ThemeService.DEVEXTREME_THEME_LINK_ID) as HTMLLinkElement | null;

    if (!themeLink) {
      themeLink = this.document.createElement('link');
      themeLink.id = ThemeService.DEVEXTREME_THEME_LINK_ID;
      themeLink.rel = 'stylesheet';
      this.document.head.appendChild(themeLink);
    }

    if (themeLink.getAttribute('href') !== href) {
      themeLink.setAttribute('href', href);
    }
  }
}

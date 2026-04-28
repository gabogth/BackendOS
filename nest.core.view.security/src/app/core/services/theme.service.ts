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

  async initialize(): Promise<void> {
    const savedTheme = this.getStoredTheme();
    await this.setTheme(savedTheme);
  }

  async setTheme(mode: ThemeMode): Promise<void> {
    const selectedTheme = this.themeMap[mode];
    const dxThemeName = mode === 'dark' 
            ? 'generic.dark.compact' 
            : 'generic.light.compact';
    localStorage.setItem(ThemeService.STORAGE_KEY, mode);
    this.currentTheme.set(mode);
    this.document.documentElement.setAttribute('data-bs-theme', selectedTheme.bootstrap);
    await this.syncDevextremeThemeLink(selectedTheme.devextreme, dxThemeName);
  }

  async toggleTheme(): Promise<void> {
    await this.setTheme(this.currentTheme() === 'light' ? 'dark' : 'light');
  }

  private getStoredTheme(): ThemeMode {
    const mode = localStorage.getItem(ThemeService.STORAGE_KEY);
    return mode === 'dark' ? 'dark' : 'light';
  }

  private syncDevextremeThemeLink(href: string, themeName: string): Promise<void> {
    return new Promise((resolve) => {
      let themeLink = this.document.getElementById(
        ThemeService.DEVEXTREME_THEME_LINK_ID
      ) as HTMLLinkElement | null;
      if (!themeLink) {
        themeLink = this.document.createElement('link');
        themeLink.id = ThemeService.DEVEXTREME_THEME_LINK_ID;
        themeLink.rel = 'stylesheet';
        this.document.head.appendChild(themeLink);
      }
      themeLink.setAttribute('data-theme', themeName);
      const onThemeLoaded = () => {
        try{
          themes.current(themeName);
          resolve();
        }catch(error){}
      };
      if (themeLink.getAttribute('href') === href) {
        themes.current(themeName);
        resolve();
        return;
      }
      themeLink.onload = onThemeLoaded;
      themeLink.href = href;
    });
  }
}

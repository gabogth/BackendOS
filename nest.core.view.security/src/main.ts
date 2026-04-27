import { bootstrapApplication } from '@angular/platform-browser';

import { AppComponent } from './app/app.component';
import { appConfig } from './app/app.config';
import { locale, loadMessages } from 'devextreme/localization';
import esMessages from 'devextreme/localization/messages/es.json';


loadMessages(esMessages);
locale('es');
bootstrapApplication(AppComponent, appConfig).catch((error: unknown) => {
  console.error('Application bootstrap failed', error);
});

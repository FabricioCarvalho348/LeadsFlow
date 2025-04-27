import { bootstrapApplication } from '@angular/platform-browser';
import { LeadsComponent } from './app/pages/leads/leads.component';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes';

import { appConfig } from './app/app.config';

bootstrapApplication(LeadsComponent, appConfig);

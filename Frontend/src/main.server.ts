import { bootstrapApplication } from '@angular/platform-browser';
import { LeadsComponent } from './app/pages/leads/leads.component';
import { config } from './app/app.config.server';

const bootstrap = () => bootstrapApplication(LeadsComponent, config);

export default bootstrap;

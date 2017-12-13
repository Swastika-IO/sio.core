import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MessengerPortalComponent } from './messenger-portal.component';

import { FooterComponent } from './components/footer/footer.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: MessengerPortalComponent,
        children: [
          // {
          //    path: '',
          //    redirectTo: 'dashboard',
          //    pathMatch: 'full'
          // },
          {
            path: '',
            loadChildren: './modules/dashboard/dashboard.module#PortalDashboardModule',
          }
        ]
      },
    ])
  ],
  exports: [RouterModule],
  declarations: [
    MessengerPortalComponent,
    FooterComponent,
    SidebarComponent
  ]
})

export class MessengerPortalModule { }   

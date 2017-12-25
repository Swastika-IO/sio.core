import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MessengerPortalComponent } from './messenger-portal.component';

import { FooterComponent } from './components/footer/footer.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    FormsModule,
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
    SidebarComponent
  ]
})

export class MessengerPortalModule { }   

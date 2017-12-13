import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BlankPortalComponent } from './blank-portal.component';

// import { FooterComponent } from './components/footer/footer.component';
// import { SidebarComponent } from './components/sidebar/sidebar.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: BlankPortalComponent,
        children: [
          //{
          //    path: '',
          //    redirectTo: 'dashboard',
          //    pathMatch: 'full'
          //},
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
    BlankPortalComponent,
    // FooterComponent,
    // SidebarComponent
  ]
})

export class BlankPortalModule { }   

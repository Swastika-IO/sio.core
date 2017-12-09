import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalComponent } from './portal.component';

import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: PortalComponent,
        children: [
          //{
          //    path: '',
          //    redirectTo: 'dashboard',
          //    pathMatch: 'full'
          //},
          {
            path: '',
            loadChildren: './modules/dashboard/dashboard.module#PortalDashboardModule',
          },
          {
            path: 'article',
            loadChildren: './modules/article/article.module#PortalArticleModule',
          },
          {
            path: 'blank',
            loadChildren: './modules/_blank/something.module#PortalSomethingModule',
          }
        ]
      },
    ])
  ],
  exports: [RouterModule],
  declarations: [
    PortalComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
  ]
})

export class PortalModule { }   

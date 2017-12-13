import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CmsPortalComponent } from './cms-portal.component';

import { FooterComponent } from './components/footer/footer.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: CmsPortalComponent,
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
            path: 'page',
            loadChildren: './modules/page/page.module#PortalPageModule',
          },
          {
            path: 'module',
            loadChildren: './modules/module/module.module#PortalModuleModule',
          },
          {
            path: 'appearance',
            loadChildren: './modules/appearance/appearance.module#PortalAppearanceModule',
          },
          {
            path: 'media',
            loadChildren: './modules/media/media.module#PortalMediaModule',
          },
          {
            path: 'user',
            loadChildren: './modules/user/user.module#PortalUserModule',
          },
          {
            path: 'setting',
            loadChildren: './modules/setting/setting.module#PortalSettingModule',
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
    CmsPortalComponent,
    FooterComponent,
    SidebarComponent
  ]
})

export class CmsPortalModule { }   

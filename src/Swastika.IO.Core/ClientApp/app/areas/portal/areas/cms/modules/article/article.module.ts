import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalArticleComponent } from './article.component';
import { ArticleService } from "../../services/article.services";
import { StorageService } from "../../services/localStorage.service";
import { ServiceHelper } from "../../service.helper";
import { ModuleService } from "../../services/module.service";
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { LocalStorageService, SessionStorageService, CookiesStorageService, SharedStorageService } from "ngx-store/dist";
import { ModuleDetailsService } from "../../services/module.details.service";
@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: PortalArticleComponent,
        children: [
          {
            path: '',
            redirectTo: 'list-article',
            pathMatch: 'full'
          },
          {
            path: 'create-article',
            loadChildren: './create-article/create-article.module#PortalCreateArticleModule',
          },
          {
            path: 'list-article',
            loadChildren: './list-article/list-article.module#PortalListArticleModule',
          },
          {
            path: 'list-draft-article',
            loadChildren: './list-draft-article/list-draft-article.module#PortalListDraftArticleModule',
          }
        ]
      },
    ])
  ],
  exports: [RouterModule],
  declarations: [
    PortalArticleComponent
  ],
  providers: [
    StorageService,
    ServiceHelper,
    ArticleService,
    ModuleService,
    ModuleDetailsService,

    Ng4LoadingSpinnerService,
    LocalStorageService,
    SessionStorageService,
    CookiesStorageService,
    SharedStorageService,
  ]
})

export class PortalArticleModule { }   

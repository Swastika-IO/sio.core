import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalCreateArticleComponent } from './create-article.component';
//import { CKEditorModule } from 'ng2-ckeditor';
import { AceEditorModule } from 'ng2-ace-editor';

import { PortalSharedModule } from '../../../portal.shared.module';

@NgModule({
  imports: [
    RouterModule.forChild([{
      path: '',
      component: PortalCreateArticleComponent
    }]),
    //CKEditorModule,
    AceEditorModule,
    PortalSharedModule
  ],
  exports: [RouterModule],
  declarations: [
    PortalCreateArticleComponent
  ]
})

export class PortalCreateArticleModule { }   

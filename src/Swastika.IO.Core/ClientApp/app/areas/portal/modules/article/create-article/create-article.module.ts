import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalCreateArticleComponent } from './create-article.component';
//import { CKEditorModule } from 'ng2-ckeditor';
import { AceEditorModule } from 'ng2-ace-editor';
import { RichtextareaComponent } from '../../../../shared/components/ng-pell/richtextarea/richtextarea.component';

@NgModule({
  imports: [
    RouterModule.forChild([{
      path: '',
      component: ProtalCreateArticleComponent
    }]),
    //CKEditorModule,
    AceEditorModule
  ],
  exports: [RouterModule],
  declarations: [
    ProtalCreateArticleComponent,
    RichtextareaComponent
  ]
})

export class PortalCreateArticleModule { }   

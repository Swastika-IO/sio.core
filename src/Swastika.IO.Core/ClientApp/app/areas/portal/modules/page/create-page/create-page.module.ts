import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalCreatePageComponent } from './create-page.component';
//import { CKEditorModule } from 'ng2-ckeditor';
import { AceEditorModule } from 'ng2-ace-editor';
//import { SharedRichTextAreaModule } from '../../_shared/ng-pell/richtextarea/richtextarea.module'
import { PortalSharedModule } from '../../../portal.shared.module';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalCreatePageComponent
      }]),
      //CKEditorModule,
      AceEditorModule,
      //SharedRichTextAreaModule,
      PortalSharedModule
    ],
    exports: [RouterModule],
    declarations: [
      PortalCreatePageComponent
    ]
})

export class PortalCreatePageModule { }   

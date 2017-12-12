import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalCreateMediaComponent } from './create-media.component';
//import { CKEditorModule } from 'ng2-ckeditor';
import { AceEditorModule } from 'ng2-ace-editor';
import { PortalSharedModule } from '../../../portal.shared.module';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalCreateMediaComponent
      }]),
      //CKEditorModule,
      AceEditorModule,
      PortalSharedModule
    ],
    exports: [RouterModule],
    declarations: [
      PortalCreateMediaComponent
    ]
})

export class PortalCreateMediaModule { }   

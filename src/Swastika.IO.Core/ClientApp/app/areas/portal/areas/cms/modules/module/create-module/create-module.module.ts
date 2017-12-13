import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalCreateModuleComponent } from './create-module.component';
//import { CKEditorModule } from 'ng2-ckeditor';
import { AceEditorModule } from 'ng2-ace-editor';
import { PortalSharedModule } from '../../../../../portal.shared.module';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalCreateModuleComponent
      }]),
      //CKEditorModule,
      AceEditorModule,
      PortalSharedModule
    ],
    exports: [RouterModule],
    declarations: [
      PortalCreateModuleComponent
    ]
})

export class PortalCreateModuleModule { }   

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalCreateSomethingComponent } from './create-something.component';
//import { CKEditorModule } from 'ng2-ckeditor';
import { AceEditorModule } from 'ng2-ace-editor';
import { PortalSharedModule } from '../../../../../portal.shared.module';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalCreateSomethingComponent
      }]),
      //CKEditorModule,
      AceEditorModule,
      PortalSharedModule
    ],
    exports: [RouterModule],
    declarations: [
      PortalCreateSomethingComponent
    ]
})

export class PortalCreateSomethingModule { }   

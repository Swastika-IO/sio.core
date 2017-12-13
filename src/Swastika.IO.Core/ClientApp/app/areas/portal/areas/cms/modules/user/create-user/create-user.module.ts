import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalCreateUserComponent } from './create-user.component';
//import { CKEditorModule } from 'ng2-ckeditor';
import { AceEditorModule } from 'ng2-ace-editor';
import { PortalSharedModule } from '../../../../../portal.shared.module';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalCreateUserComponent
      }]),
      //CKEditorModule,
      AceEditorModule,
      PortalSharedModule
    ],
    exports: [RouterModule],
    declarations: [
      PortalCreateUserComponent
    ]
})

export class PortalCreateUserModule { }   

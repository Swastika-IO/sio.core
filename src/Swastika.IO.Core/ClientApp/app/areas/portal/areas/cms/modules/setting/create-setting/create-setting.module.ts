import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalCreateSettingComponent } from './create-setting.component';
//import { CKEditorModule } from 'ng2-ckeditor';
import { AceEditorModule } from 'ng2-ace-editor';
import { PortalSharedModule } from '../../../../../portal.shared.module';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalCreateSettingComponent
      }]),
      //CKEditorModule,
      AceEditorModule,
      PortalSharedModule
    ],
    exports: [RouterModule],
    declarations: [
      PortalCreateSettingComponent
    ]
})

export class PortalCreateSettingModule { }   

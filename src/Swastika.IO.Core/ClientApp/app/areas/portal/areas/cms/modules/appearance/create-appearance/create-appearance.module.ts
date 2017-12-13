import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalCreateAppearanceComponent } from './create-appearance.component';
//import { CKEditorModule } from 'ng2-ckeditor';
import { AceEditorModule } from 'ng2-ace-editor';
import { PortalSharedModule } from '../../../../../portal.shared.module';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalCreateAppearanceComponent
      }]),
      //CKEditorModule,
      AceEditorModule,
      PortalSharedModule
    ],
    exports: [RouterModule],
    declarations: [
      PortalCreateAppearanceComponent
    ]
})

export class PortalCreateAppearanceModule { }   

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListDraftSettingComponent } from './list-draft-setting.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListDraftSettingComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListDraftSettingComponent
    ]
})

export class PortalListDraftSettingModule { }   

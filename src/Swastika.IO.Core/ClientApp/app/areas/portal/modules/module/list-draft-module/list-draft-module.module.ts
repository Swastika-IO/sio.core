import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListDraftModuleComponent } from './list-draft-module.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListDraftModuleComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListDraftModuleComponent
    ]
})

export class PortalListDraftModuleModule { }   

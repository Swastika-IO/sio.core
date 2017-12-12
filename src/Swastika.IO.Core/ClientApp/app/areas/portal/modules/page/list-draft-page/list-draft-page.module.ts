import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListDraftPageComponent } from './list-draft-page.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListDraftPageComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListDraftPageComponent
    ]
})

export class PortalListDraftPageModule { }   

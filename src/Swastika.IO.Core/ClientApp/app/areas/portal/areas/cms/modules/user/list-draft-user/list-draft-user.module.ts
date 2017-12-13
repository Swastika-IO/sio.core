import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListDraftUserComponent } from './list-draft-user.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListDraftUserComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListDraftUserComponent
    ]
})

export class PortalListDraftUserModule { }   

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListDraftSomethingComponent } from './list-draft-something.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListDraftSomethingComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListDraftSomethingComponent
    ]
})

export class PortalListDraftSomethingModule { }   
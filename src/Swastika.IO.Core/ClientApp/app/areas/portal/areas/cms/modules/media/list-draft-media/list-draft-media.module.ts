import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListDraftMediaComponent } from './list-draft-media.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListDraftMediaComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListDraftMediaComponent
    ]
})

export class PortalListDraftMediaModule { }   

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListSomethingComponent } from './list-something.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListSomethingComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListSomethingComponent
    ]
})

export class PortalListSomethingModule { }   
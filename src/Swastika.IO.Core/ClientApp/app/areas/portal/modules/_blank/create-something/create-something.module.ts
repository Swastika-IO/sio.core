import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalCreateSomethingComponent } from './create-something.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalCreateSomethingComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalCreateSomethingComponent
    ]
})

export class PortalCreateSomethingModule { }   
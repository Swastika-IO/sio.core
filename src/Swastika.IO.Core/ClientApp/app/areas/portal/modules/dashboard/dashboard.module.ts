import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalDashboardComponent } from './dashboard.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalDashboardComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalDashboardComponent
    ]
})

export class PortalDashboardModule { }   
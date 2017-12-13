import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalDashboardComponent } from './dashboard.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: PortalDashboardComponent,
                children: [
                    // {
                    //     path: '',
                    //     redirectTo: 'list-dashboard',
                    //     pathMatch: 'full'
                    // },
                    // {
                    //     path: 'create-dashboard',
                    //     loadChildren: './create-dashboard/create-dashboard.module#PortalCreateDashboardModule',
                    // },
                    // {
                    //     path: 'list-dashboard',
                    //     loadChildren: './list-dashboard/list-dashboard.module#PortalListDashboardModule',
                    // },
                    // {
                    //     path: 'list-draft-dashboard',
                    //     loadChildren: './list-draft-dashboard/list-draft-dashboard.module#PortalListDraftDashboardModule',
                    // }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalDashboardComponent
    ]
})

export class PortalDashboardModule { }   

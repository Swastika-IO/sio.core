import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalUserComponent } from './user.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: PortalUserComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'list-user',
                        pathMatch: 'full'
                    },
                    {
                        path: 'create-user',
                        loadChildren: './create-user/create-user.module#PortalCreateUserModule',
                    },
                    {
                        path: 'list-user',
                        loadChildren: './list-user/list-user.module#PortalListUserModule',
                    },
                    {
                        path: 'list-draft-user',
                        loadChildren: './list-draft-user/list-draft-user.module#PortalListDraftUserModule',
                    }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalUserComponent
    ]
})

export class PortalUserModule { }   

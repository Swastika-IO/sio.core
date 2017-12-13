import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalSomethingComponent } from './something.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: PortalSomethingComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'list-something',
                        pathMatch: 'full'
                    },
                    {
                        path: 'create-something',
                        loadChildren: './create-something/create-something.module#PortalCreateSomethingModule',
                    },
                    {
                        path: 'list-something',
                        loadChildren: './list-something/list-something.module#PortalListSomethingModule',
                    },
                    {
                        path: 'list-draft-something',
                        loadChildren: './list-draft-something/list-draft-something.module#PortalListDraftSomethingModule',
                    }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalSomethingComponent
    ]
})

export class PortalSomethingModule { }   
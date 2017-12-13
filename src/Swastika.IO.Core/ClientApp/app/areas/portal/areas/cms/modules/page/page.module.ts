import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalPageComponent } from './page.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: PortalPageComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'list-page',
                        pathMatch: 'full'
                    },
                    {
                        path: 'create-page',
                        loadChildren: './create-page/create-page.module#PortalCreatePageModule',
                    },
                    {
                        path: 'list-page',
                        loadChildren: './list-page/list-page.module#PortalListPageModule',
                    },
                    {
                        path: 'list-draft-page',
                        loadChildren: './list-draft-page/list-draft-page.module#PortalListDraftPageModule',
                    }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalPageComponent
    ]
})

export class PortalPageModule { }   

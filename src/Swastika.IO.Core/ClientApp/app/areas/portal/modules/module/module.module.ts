import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalModuleComponent } from './module.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: PortalModuleComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'list-module',
                        pathMatch: 'full'
                    },
                    {
                        path: 'create-module',
                        loadChildren: './create-module/create-module.module#PortalCreateModuleModule',
                    },
                    {
                        path: 'list-module',
                        loadChildren: './list-module/list-module.module#PortalListModuleModule',
                    },
                    {
                        path: 'list-draft-module',
                        loadChildren: './list-draft-module/list-draft-module.module#PortalListDraftModuleModule',
                    }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalModuleComponent
    ]
})

export class PortalModuleModule { }   

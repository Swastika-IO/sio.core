import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalMediaComponent } from './media.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: PortalMediaComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'list-media',
                        pathMatch: 'full'
                    },
                    {
                        path: 'create-media',
                        loadChildren: './create-media/create-media.module#PortalCreateMediaModule',
                    },
                    {
                        path: 'list-media',
                        loadChildren: './list-media/list-media.module#PortalListMediaModule',
                    },
                    {
                        path: 'list-draft-media',
                        loadChildren: './list-draft-media/list-draft-media.module#PortalListDraftMediaModule',
                    }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalMediaComponent
    ]
})

export class PortalMediaModule { }   

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalAppearanceComponent } from './appearance.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: PortalAppearanceComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'list-appearance',
                        pathMatch: 'full'
                    },
                    {
                        path: 'create-appearance',
                        loadChildren: './create-appearance/create-appearance.module#PortalCreateAppearanceModule',
                    },
                    {
                        path: 'list-appearance',
                        loadChildren: './list-appearance/list-appearance.module#PortalListAppearanceModule',
                    },
                    {
                        path: 'list-draft-appearance',
                        loadChildren: './list-draft-appearance/list-draft-appearance.module#PortalListDraftAppearanceModule',
                    }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalAppearanceComponent
    ]
})

export class PortalAppearanceModule { }   

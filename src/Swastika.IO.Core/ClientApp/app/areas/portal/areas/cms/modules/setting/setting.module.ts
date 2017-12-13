import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalSettingComponent } from './setting.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: PortalSettingComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'list-setting',
                        pathMatch: 'full'
                    },
                    {
                        path: 'create-setting',
                        loadChildren: './create-setting/create-setting.module#PortalCreateSettingModule',
                    },
                    {
                        path: 'list-setting',
                        loadChildren: './list-setting/list-setting.module#PortalListSettingModule',
                    },
                    {
                        path: 'list-draft-setting',
                        loadChildren: './list-draft-setting/list-draft-setting.module#PortalListDraftSettingModule',
                    }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalSettingComponent
    ]
})

export class PortalSettingModule { }   

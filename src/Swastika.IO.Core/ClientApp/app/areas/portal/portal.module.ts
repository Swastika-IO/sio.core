import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalComponent } from './portal.component';

import { HeaderComponent } from './components/header/header.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
//import { ProtalArticleComponent } from './modules/article/article.component';
//import { FeaturesComponent } from '../../components/modules/portal/features/features.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                //redirectTo: 'dashboard',
                component: PortalComponent,
                children: [
                    {
                        path: 'dashboard',
                        loadChildren: './modules/dashboard/dashboard.module#PortalDashboardModule',
                    },
                    {
                        path: 'article',
                        loadChildren: './modules/article/article.module#PortalArticleModule',
                    }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalComponent,
        HeaderComponent,
        SidebarComponent,
        //ProtalArticleComponent
        //FeaturesComponent
    ]
})

export class PortalModule { }   
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalArticleComponent } from './article.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: PortalArticleComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'list-article',
                        pathMatch: 'full'
                    },
                    {
                        path: 'create-article',
                        loadChildren: './create-article/create-article.module#PortalCreateArticleModule',
                    },
                    {
                        path: 'list-article',
                        loadChildren: './list-article/list-article.module#PortalListArticleModule',
                    }
                ]
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        PortalArticleComponent
    ]
})

export class PortalArticleModule { }   
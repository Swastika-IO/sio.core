import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListArticleComponent } from './list-article.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListArticleComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListArticleComponent
    ]
})

export class PortalListArticleModule { }   
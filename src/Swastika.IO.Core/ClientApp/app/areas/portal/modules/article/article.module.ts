import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalArticleComponent } from './article.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalArticleComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalArticleComponent
    ]
})

export class PortalArticleModule { }   
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalCreateArticleComponent } from './create-article.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalCreateArticleComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalCreateArticleComponent
    ]
})

export class PortalCreateArticleModule { }   
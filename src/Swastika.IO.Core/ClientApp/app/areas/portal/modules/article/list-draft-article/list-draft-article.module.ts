import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListDraftArticleComponent } from './list-draft-article.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListDraftArticleComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListDraftArticleComponent
    ]
})

export class PortalListDraftArticleModule { }   
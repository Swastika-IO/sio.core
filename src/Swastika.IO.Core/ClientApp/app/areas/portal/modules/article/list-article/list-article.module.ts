import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListArticleComponent } from './list-article.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListArticleComponent
        }]),
        Ng2SmartTableModule
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListArticleComponent
    ]
})

export class PortalListArticleModule { }   

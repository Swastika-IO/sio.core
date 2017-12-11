import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListArticleComponent } from './list-article.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListArticleComponent
        }]),
      Ng2SmartTableModule,
      NgxDatatableModule
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListArticleComponent
    ]
})

export class PortalListArticleModule { }   

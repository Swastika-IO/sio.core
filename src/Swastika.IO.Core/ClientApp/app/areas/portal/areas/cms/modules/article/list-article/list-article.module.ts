import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalListArticleComponent } from './list-article.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalListArticleComponent
        }]),
      Ng2SmartTableModule,
      NgxDatatableModule
    ],
    exports: [RouterModule],
    declarations: [
      PortalListArticleComponent
    ]
})

export class PortalListArticleModule { }   

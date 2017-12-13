import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalListPageComponent } from './list-page.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalListPageComponent
      }]),
      Ng2SmartTableModule,
      NgxDatatableModule
    ],
    exports: [RouterModule],
    declarations: [
      PortalListPageComponent
    ]
})

export class PortalListPageModule { }   

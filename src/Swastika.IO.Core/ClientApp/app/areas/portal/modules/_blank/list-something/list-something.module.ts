import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalListSomethingComponent } from './list-something.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  imports: [
    RouterModule.forChild([{
      path: '',
      component: PortalListSomethingComponent
    }]),
    Ng2SmartTableModule,
    NgxDatatableModule
  ],
  exports: [RouterModule],
  declarations: [
    PortalListSomethingComponent
  ]
})

export class PortalListSomethingModule { }   

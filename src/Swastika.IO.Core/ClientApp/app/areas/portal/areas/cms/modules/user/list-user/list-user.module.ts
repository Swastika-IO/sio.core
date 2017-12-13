import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalListUserComponent } from './list-user.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  imports: [
    RouterModule.forChild([{
      path: '',
      component: PortalListUserComponent
    }]),
    Ng2SmartTableModule,
    NgxDatatableModule
  ],
  exports: [RouterModule],
  declarations: [
    PortalListUserComponent
  ]
})

export class PortalListUserModule { }   

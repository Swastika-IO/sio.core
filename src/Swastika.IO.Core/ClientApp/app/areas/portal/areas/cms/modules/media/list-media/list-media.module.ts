import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalListMediaComponent } from './list-media.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  imports: [
    RouterModule.forChild([{
      path: '',
      component: PortalListMediaComponent
    }]),
    Ng2SmartTableModule,
    NgxDatatableModule
  ],
  exports: [RouterModule],
  declarations: [
    PortalListMediaComponent
  ]
})

export class PortalListMediaModule { }   

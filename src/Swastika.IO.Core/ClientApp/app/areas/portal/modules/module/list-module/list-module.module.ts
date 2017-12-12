import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalListModuleComponent } from './list-module.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  imports: [
    RouterModule.forChild([{
      path: '',
      component: PortalListModuleComponent
    }]),
    Ng2SmartTableModule,
    NgxDatatableModule
  ],
  exports: [RouterModule],
  declarations: [
    PortalListModuleComponent
  ]
})

export class PortalListModuleModule { }   

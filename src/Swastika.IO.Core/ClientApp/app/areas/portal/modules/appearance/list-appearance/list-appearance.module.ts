import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalListAppearanceComponent } from './list-appearance.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  imports: [
    RouterModule.forChild([{
      path: '',
      component: PortalListAppearanceComponent
    }]),
    Ng2SmartTableModule,
    NgxDatatableModule
  ],
  exports: [RouterModule],
  declarations: [
    PortalListAppearanceComponent
  ]
})

export class PortalListAppearanceModule { }   

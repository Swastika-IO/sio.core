import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalListSettingComponent } from './list-setting.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  imports: [
    RouterModule.forChild([{
      path: '',
      component: PortalListSettingComponent
    }]),
    Ng2SmartTableModule,
    NgxDatatableModule
  ],
  exports: [RouterModule],
  declarations: [
    PortalListSettingComponent
  ]
})

export class PortalListSettingModule { }   

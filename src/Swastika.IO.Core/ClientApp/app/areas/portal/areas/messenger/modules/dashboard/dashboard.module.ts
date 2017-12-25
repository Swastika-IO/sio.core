import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalDashboardComponent } from './dashboard.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FooterComponent } from "../../components/footer/footer.component";

@NgModule({
  imports: [
    FormsModule,CommonModule,
    RouterModule.forChild([{
      path: '',
      component: ProtalDashboardComponent
    }])
  ],
  exports: [RouterModule],
  declarations: [
    ProtalDashboardComponent,
    FooterComponent
  ]
})

export class PortalDashboardModule {
 
}   

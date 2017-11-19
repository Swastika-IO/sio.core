import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            //{
            //    path: '',
            //    redirectTo: 'front',
            //    pathMatch: 'full'
            //},
            {
                path: '',
                loadChildren: './areas/front/front.module#FrontModule'
            },
            {
                path: 'portal',
                loadChildren: './areas/portal/portal.module#PortalModule'
            },
            { path: '**', redirectTo: '' }
        ])
    ]
})
export class AppModuleShared {
}

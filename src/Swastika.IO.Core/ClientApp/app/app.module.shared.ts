import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            {
                path: 'home',
                loadChildren: './components/home/home.module#HomeModule'
            },
            {
                path: 'counter',
                loadChildren: './components/counter/counter.module#CounterModule'
            },
            {
                path: 'fetch-data',
                loadChildren: './components/fetchdata/fetchdata.module#FetchdataModule'
            },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { AppRoutingModule } from './app-routing.module';
import { NavMenuComponent } from './components/shared/navmenu/navmenu.component';
import { FooterComponent } from './components/shared/footer/footer.component';

//const routes: Routes = [
//    { path: '', redirectTo: 'home', pathMatch: 'full' },
//    {
//        path: 'home',
//        loadChildren: './pages/home/home.module#HomeModule'
//    },
//    {
//        path: 'blog',
//        loadChildren: './pages/blog/blog.module#BlogModule'
//    },
//    {
//        path: 'blog-detail/:id',
//        loadChildren: './pages/blog/item/item.module#ItemModule'
//    },
//    {
//        path: 'counter',
//        loadChildren: './pages/counter/counter.module#CounterModule'
//    },
//    {
//        path: 'fetch-data',
//        loadChildren: './pages/fetchdata/fetchdata.module#FetchdataModule'
//    },
//    { path: '**', redirectTo: 'home' }
//];

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        FooterComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        AppRoutingModule,
        //RouterModule.forRoot(routes)
    ]
})
export class AppModuleShared {
}

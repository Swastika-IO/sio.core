import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FrontComponent } from './front.component';

import { NavMenuComponent } from './components/shared/navmenu/navmenu.component';
import { FooterComponent } from './components/shared/footer/footer.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: FrontComponent
            },
            {
                path: 'home',
                loadChildren: './modules/home/home.module#HomeModule'
            },
            {
                path: 'blog',
                loadChildren: './modules/blog/blog.module#BlogModule'
            },
            {
                path: 'blog-detail/:id',
                loadChildren: './modules/blog-item/item.module#ItemModule'
            },
            {
                path: 'counter',
                loadChildren: './modules/counter/counter.module#CounterModule'
            },
            {
                path: 'fetch-data',
                loadChildren: './modules/fetchdata/fetchdata.module#FetchdataModule'
            },
        ])
    ],
    exports: [RouterModule],
    declarations: [
        FrontComponent,
        NavMenuComponent,
        FooterComponent
    ]
})

export class FrontModule { }   
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BlogComponent } from './blog.component';

import { HeaderComponent } from './header/header.component';
import { ListComponent } from './list/list.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '', 
                component: BlogComponent,
            }
        ]),
    ],
    exports: [RouterModule],
    declarations: [
        BlogComponent,
        HeaderComponent,
        ListComponent
    ]
})

export class BlogModule { }   
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ItemComponent } from './item.component';

//import { HeaderComponent } from '../../components/modules/blog/header/header.component';
//import { ListComponent } from '../../components/modules/blog/list/list.component';

@NgModule({
    imports: [
        RouterModule.forChild([{ path: '', component: ItemComponent }])
    ],
    exports: [RouterModule],
    declarations: [
        ItemComponent
    ]
})

export class ItemModule { }   
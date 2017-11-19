import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FetchDataComponent } from './fetchdata.component';

@NgModule({
    imports: [
        RouterModule.forChild([{ path: '', component: FetchDataComponent }])
    ],
    exports: [RouterModule],
    declarations: [FetchDataComponent]
})

export class FetchdataModule { }   
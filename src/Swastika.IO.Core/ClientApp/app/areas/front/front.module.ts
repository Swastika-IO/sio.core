import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FrontComponent } from './front.component';

//import { HeaderComponent } from '../../components/modules/front/header/header.component';
//import { FeaturesComponent } from '../../components/modules/front/features/features.component';

@NgModule({
    imports: [
        RouterModule.forChild([{ path: '', component: FrontComponent }])
    ],
    exports: [RouterModule],
    declarations: [
        FrontComponent,
        //HeaderComponent,
        //FeaturesComponent
    ]
})

export class FrontModule { }   
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

import { HeaderComponent } from './components/header/header.component';
import { FeaturesComponent } from './components/features/features.component';

@NgModule({
    imports: [
        RouterModule.forChild([{ path: '', component: HomeComponent }])
    ],
    exports: [RouterModule],
    declarations: [
        HomeComponent,
        HeaderComponent,
        FeaturesComponent
    ]
})

export class HomeModule { }   
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PortalComponent } from './portal.component';

import { HeaderComponent } from './components/header/header.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';

//import { FeaturesComponent } from '../../components/modules/home/features/features.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: PortalComponent
        }])
    ],
    exports: [
        RouterModule
    ],
    declarations: [
        PortalComponent,
        HeaderComponent,
        SidebarComponent
        //FeaturesComponent
    ]
})

export class PortalModule { }   
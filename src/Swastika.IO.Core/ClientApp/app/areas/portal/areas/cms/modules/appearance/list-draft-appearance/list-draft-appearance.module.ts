import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalListDraftAppearanceComponent } from './list-draft-appearance.component';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalListDraftAppearanceComponent
        }])
    ],
    exports: [RouterModule],
    declarations: [
        ProtalListDraftAppearanceComponent
    ]
})

export class PortalListDraftAppearanceModule { }   

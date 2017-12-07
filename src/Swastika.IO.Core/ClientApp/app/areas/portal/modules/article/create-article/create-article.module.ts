import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProtalCreateArticleComponent } from './create-article.component';
import { CKEditorModule } from 'ng2-ckeditor';

@NgModule({
    imports: [
        RouterModule.forChild([{
            path: '',
            component: ProtalCreateArticleComponent
      }]),
        CKEditorModule
    ],
    exports: [RouterModule],
    declarations: [
        ProtalCreateArticleComponent
    ]
})

export class PortalCreateArticleModule { }   

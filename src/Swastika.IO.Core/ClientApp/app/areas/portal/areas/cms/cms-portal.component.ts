import { Component, ViewEncapsulation } from '@angular/core';

@Component({
    selector: 'cms-portal',
    styleUrls: [
        './cms-portal.component.scss'
    ],
    templateUrl: './cms-portal.component.html',
    encapsulation: ViewEncapsulation.None
})
export class CmsPortalComponent {
  paceOptions = {
    ajax: true,
    document: true,
    eventLag: true,
    elements: {
      selectors: ['.my-page']
    }
  };
}

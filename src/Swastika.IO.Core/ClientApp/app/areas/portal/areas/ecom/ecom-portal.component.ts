import { Component, ViewEncapsulation } from '@angular/core';

@Component({
    selector: 'ecom-portal',
    styleUrls: [
        './ecom-portal.component.scss'
    ],
    templateUrl: './ecom-portal.component.html',
    encapsulation: ViewEncapsulation.None
})
export class EcomPortalComponent {
  paceOptions = {
    ajax: true,
    document: true,
    eventLag: true,
    elements: {
      selectors: ['.my-page']
    }
  };
}

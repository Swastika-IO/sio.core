import { Component, ViewEncapsulation } from '@angular/core';

@Component({
    selector: 'blank-portal',
    styleUrls: [
        './blank-portal.component.scss'
    ],
    templateUrl: './blank-portal.component.html',
    encapsulation: ViewEncapsulation.None
})
export class BlankPortalComponent {
  paceOptions = {
    ajax: true,
    document: true,
    eventLag: true,
    elements: {
      selectors: ['.my-page']
    }
  };
}

import { Component, ViewEncapsulation } from '@angular/core';

@Component({
    selector: 'portal',
    styleUrls: [
        //'./themes/swastika-io-admin/css/portal.css',
        //'./themes/swastika-io-admin/font/css/open-iconic-bootstrap.css',
        './portal.component.scss'
    ],
    templateUrl: './portal.component.html',
    encapsulation: ViewEncapsulation.None
})
export class PortalComponent {
  paceOptions = {
    ajax: true,
    document: true,
    eventLag: true,
    elements: {
      selectors: ['.my-page']
    }
  };
}

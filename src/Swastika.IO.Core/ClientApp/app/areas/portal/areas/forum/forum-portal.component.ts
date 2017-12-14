import { Component, ViewEncapsulation } from '@angular/core';

@Component({
    selector: 'forum-portal',
    styleUrls: [
        './forum-portal.component.scss'
    ],
    templateUrl: './forum-portal.component.html',
    encapsulation: ViewEncapsulation.None
})
export class ForumPortalComponent {
  paceOptions = {
    ajax: true,
    document: true,
    eventLag: true,
    elements: {
      selectors: ['.my-page']
    }
  };
}

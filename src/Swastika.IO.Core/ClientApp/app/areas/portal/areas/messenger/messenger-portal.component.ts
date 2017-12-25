import { Component, OnInit, ViewEncapsulation } from '@angular/core';

import { HubConnection, TransportType } from '@aspnet/signalr-client';
import * as models from './messenger.viewmodels';

import { forEach } from '@angular/router/src/utils/collection';
import { PagingItems, Team } from './messenger.viewmodels';

import { FooterComponent } from './components/footer/footer.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ProtalDashboardComponent } from "./modules/dashboard/dashboard.component";
//@Component({
//    selector: 'messenger-portal',
//    styleUrls: [
//        './messenger-portal.component.scss'
//    ],
//    templateUrl: './messenger-portal.component.html',
//    encapsulation: ViewEncapsulation.None
//})
//export class MessengerPortalComponent {
    
//}

@Component({
    selector: 'messenger-portal',
    styleUrls: [
        './messenger-portal.component.scss'
    ],
    templateUrl: './messenger-portal.component.html',
    encapsulation: ViewEncapsulation.None,
})
export class MessengerPortalComponent {
 
}

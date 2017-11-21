import { Injectable, EventEmitter } from '@angular/core';

@Injectable()
export class PortalService {
    public toggleSidebar: EventEmitter<any> = new EventEmitter();
}
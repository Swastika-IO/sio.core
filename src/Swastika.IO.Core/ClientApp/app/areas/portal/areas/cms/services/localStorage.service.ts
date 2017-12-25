import {
  CookiesStorageService, LocalStorageService, SessionStorageService
  , SharedStorageService
} from 'ngx-store';
import { Component, Injectable } from '@angular/core';

@Injectable()
export class StorageService {
    constructor(
        private localStorageService: LocalStorageService,
        private sessionStorageService: SessionStorageService,
        private cookiesStorageService: CookiesStorageService,
        private sharedStorageService: SharedStorageService,
    ) {
        // console.log('all cookies:');
        // cookiesStorageService.utility.forEach((value, key) => console.log(key + '=', value));
    }

    public saveLocalData(key: string, data: any) {        
        this.localStorageService.set(key, data);  
    }

    public  getLocalData(key: string): any {        
        return localStorage.getItem(key);
    }

    public  clearLocalData(key: string): void {        
        this.localStorageService.set(key, null); // removes only variables created by decorating functions
    }

    public saveSomeData(object: Object, array: Array<any>) {
        this.localStorageService.set('someObject', object);
        this.sessionStorageService.set('someArray', array);

        this.localStorageService.keys.forEach((key) => {
            console.log(key + ' =', this.localStorageService.get(key));
        });
    }

    public clearSomeData(): void {
        this.localStorageService.clear('decorators'); // removes only variables created by decorating functions
        this.localStorageService.clear('prefix'); // removes variables starting with set prefix (including decorators)
        this.sessionStorageService.clear('all'); // removes all session storage data
    }
}

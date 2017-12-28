/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MessengerComponent } from './messenger.component';

let component: MessengerComponent;
let fixture: ComponentFixture<MessengerComponent>;

describe('messenger component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ MessengerComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(MessengerComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
import { Component, Input, OnInit } from '@angular/core';

import { ViewCell } from 'ng2-smart-table';

@Component({
  template: `
    <img src="{{renderValue}}" height="50px"/>
  `
})
export class ImageRenderComponent implements ViewCell, OnInit {

  renderValue: any;

  @Input() value: string | number;
  @Input() rowData: any;

  ngOnInit() {
    this.renderValue = this.value;
  }

}

@Component({
  template: `
  <ng-container *ngIf="renderValue">
    <div [innerHtml]="renderValue"></div>
  </ng-container>
  `,
})
export class HtmlRenderComponent implements ViewCell, OnInit {

  renderValue: any;

  @Input() value: string | number;
  @Input() rowData: any;

  ngOnInit() {
    this.renderValue = this.value;
  }

}

@Component({
  template: `
  {{renderValue}}
  `,
})
export class DatetimeRenderComponent implements ViewCell, OnInit {

  renderValue: any;

  @Input() value: string;
  @Input() rowData: any;

  ngOnInit() {
    // return if input date is null or undefined
    if (!this.value) {
      return;
    }
    // append 'Z' to the date string to indicate UTC time if the timezone isn't already specified
    if (this.value.indexOf('Z') === -1 && this.value.indexOf('+') === -1) {
      this.value += 'Z';
    }
    const date = new Date(this.value);
    this.renderValue = date.toDateString();
  }
}


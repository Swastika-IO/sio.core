import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Message } from "../../messenger.viewmodels";

@Component({
    selector: 'sw-footer',
    templateUrl: './footer.component.html',
    styleUrls: ['./footer.component.scss']
})
export class FooterComponent {
  @Input() message: Message;
  @Output() onSendMessage: EventEmitter<any> = new EventEmitter();

  sendMessage() {
    console.log(this.message)
    this.onSendMessage.emit();
  }
}

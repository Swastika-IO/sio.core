import { Component, OnInit, OnChanges, AfterViewInit, Input, Output, EventEmitter } from '@angular/core';
import { ElementRef, Renderer2, ViewChild, ViewEncapsulation } from '@angular/core';
import * as pell from './pell.library'


@Component({
  selector: 'richtextarea',
  templateUrl: './richtextarea.component.html',
  styleUrls: ['./richtextarea.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class RichtextareaComponent implements OnInit, AfterViewInit, OnChanges {

  constructor(
    private rd: Renderer2
    
  ) { }

  ngOnInit() {
  }

  @ViewChild('wysiwyg') wysiwyg: ElementRef

  ngAfterViewInit(){
    this.wysiwygInit(this.wysiwyg.nativeElement, this.actions)
    this.editor.content.innerHTML = this.value;
  }

  ngOnChanges(changes: any) {
      try {
        if (this.editor.content.innerHTML != this.value) {
          this.editor.content.innerHTML = this.value
        }        
      } catch (err) {

      }
  }

  @Input() actions:Array<Object> = []
  @Input() value:String = ""
  @Output() valueChange = new EventEmitter()
  pell = pell
  html  
  editor

  wysiwygInit(elm, actions) {
      this.editor = pell.init({
        element: elm, 
        onChange: html => {
          this.html = html
          this.valueChange.emit(this.html)
        },
        styleWithCSS: true,
        actions: [
          "bold",
          "underline",
          {
            name: "italic",
            result: () => this.pell.exec("italic")
          },
          "strikethrough",
          "heading1",
          "heading2",
          "paragraph",
          "quote",
          "olist",
          "ulist",
          "code",
          "line",
          {
            name: "image",
            result: () => {
              const url = window.prompt("Enter the image URL");
              if (url) this.pell.exec("insertImage", url);
            }
          },
          {
            name: "link",
            result: () => {
              const url = window.prompt("Enter the link URL");
              if (url) this.pell.exec("createLink", url);
            }
          }
        ].concat(actions),
        classes: {}
      });
  }
}

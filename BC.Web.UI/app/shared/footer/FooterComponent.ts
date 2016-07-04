import { Component } from "angular2/core";

@Component({
  selector: "[bcFooter]",
  template: `
            
                <div class="row-wrapper clearfix">
                  Here is your footer
                </div>
      
            `,
  styles: [
    `
      .footer {
        display: block;
        position: absolute;
        bottom: 0;
        width: 100%;
        height: 60px;
        background-color: #c5c5c5;
      }
      .row-wrapper {
        max-width: 960px;
        margin: 0 auto;
      }
    `
  ]
})
export default class PaymentsComponent {

}
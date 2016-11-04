import { Component } from "@angular/core";

// Styles
import "./assets/_styles.scss";

@Component({
  selector: "[bcFooter]",
  template: `
            
                <div class="row-wrapper clearfix">
                  Here is your footer
                </div>
      
            `
})
export default class FooterComponent {
  constructor() {}
}
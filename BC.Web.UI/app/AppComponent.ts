import { Component } from "@angular/core";
import { AUTH_PROVIDERS } from "angular2-jwt";

// Styles
import "./components/shared/assets/_styles.scss";

@Component({
  selector: "[myApp]",
  template: `
              <bc-header></bc-header>
              <main class="main row-wrapper clearfix">
                <router-outlet></router-outlet>
              </main>
              <footer bcFooter class="footer"></footer>
            `
})
export default class AppComponent {
  constructor() {}
}

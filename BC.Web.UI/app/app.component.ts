import { Component } from "@angular/core";
// import { ROUTER_DIRECTIVES } from '@angular/router';
// import { APP_BASE_HREF } from '@angular/platform/common';
// import { HTTP_PROVIDERS } from "@angular/http";
import { AUTH_PROVIDERS } from "angular2-jwt";

import HomeComponent from "./components/home/HomeComponent";
import AboutComponent from "./components/about/AboutComponent";
import NewsComponent from "./components/news/NewsComponent";
import ProjectsComponent from "./components/projects/ProjectsComponent";
import PaymentsComponent from "./components/payments/PaymentsComponent";
import SignInComponent from "./components/authorization/signIn/SignInComponent";
import SignUpComponent from "./components/authorization/signUp/SignUpComponent";


@Component({
  selector: "[myApp]",
  // directives: [
  //   ROUTER_DIRECTIVES,
  //   HeaderComponent,
  //   FooterComponent
  // ],
  providers: [

  ],
  template: `
              <bc-header></bc-header>
              <main class="main row-wrapper clearfix">
                <router-outlet></router-outlet>
              </main>
              <footer bcFooter class="footer"></footer>
            `,
  styles: [`
            .row-wrapper {
              max-width: 960px;
              margin: 0 auto;
            }
            .main {

            }
                  .footer {
        display: block;
        position: absolute;
        bottom: 0;
        width: 100%;
        height: 60px;
        background-color: #c5c5c5;
      }
          `]
})
export class AppComponent {
  constructor() {

  }

}

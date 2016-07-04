import { Component, provide } from "angular2/core";
import { ROUTER_PROVIDERS, ROUTER_DIRECTIVES, RouteConfig } from 'angular2/router';
import { APP_BASE_HREF } from 'angular2/platform/common';
import HomeComponent from "./components/home/HomeComponent";
import AboutComponent from "./components/about/AboutComponent";
import NewsComponent from "./components/news/NewsComponent";
import ProjectsComponent from "./components/projects/ProjectsComponent";
import PaymentsComponent from "./components/payments/PaymentsComponent";
import HeaderComponent from "./shared/header/HeaderComponent";
import FooterComponent from "./shared/footer/FooterComponent";

@Component({
  selector: "[myApp]",
  directives: [ROUTER_DIRECTIVES, HeaderComponent, FooterComponent],
  providers: [
    ROUTER_PROVIDERS,
    provide(APP_BASE_HREF, {useValue : '/' })
  ],
  template: `
              <bc-header></bc-header>
              <main class="main row-wrapper clearfix">
                <router-outlet></router-outlet>
              </main>
              <footer bcFooter class="footer"></footer>
            `,
  // template: `
  //             <h1 class="red">Hello World Component</h1>
  //             <ul>
  //               <li *ngFor="let item of [1,2,3]">{{item}}</li>
  //             </ul>
  //             <button type="button" (click)="toggle()">Show</button>
  //             <div class="myDiv" *ngIf="toggler">show or hide :)</div>
  //           `,
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
@RouteConfig([
  { path: '/', name: "Home", component: HomeComponent, useAsDefault: true},
  { path: "/about", name: "About", component: AboutComponent },
  { path: "/news", name: "News", component: NewsComponent },
  { path: "/projects", name: "Projects", component: ProjectsComponent },
  { path: "/payments", name: "Payments", component: PaymentsComponent }
])
export class AppComponent {
  public toggler: boolean;

  constructor() {
    this.toggler = true;
  }

  public toggle(): void {
    console.log("called: ");
    this.toggler = !this.toggler;
  }
}

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from "@angular/http";
import { APP_BASE_HREF } from '@angular/common';
import { provideStore } from "@ngrx/store";
import { AUTH_PROVIDERS, JwtHelper } from "angular2-jwt";

// Components
import AppComponent from './AppComponent';
import HomeComponent from "./components/home/HomeComponent";
import AboutComponent from "./components/about/AboutComponent";
import NewsComponent from "./components/news/NewsComponent";
import ProjectsComponent from "./components/projects/ProjectsComponent";
import PaymentsComponent from "./components/payments/PaymentsComponent";
import SignInComponent from "./components/authorization/signIn/SignInComponent";
import SignUpComponent from "./components/authorization/signUp/SignUpComponent";
import ProfileComponent from "./components/authorization/profile/ProfileComponent";
import FooterComponent from "./components/shared/footer/FooterComponent";
import HeaderComponent from "./components/shared/header/HeaderComponent";
import AuthComponent from "./components/shared/header/AuthComponent";

// Routes
import { ROUTER_MODULE } from "./AppRoutes";

// Services
import AuthService from "./components/authorization/AuthService";
import ProfileGuardService from "./components/authorization/profile/ProfileGuardService";

// Reducers
import { root } from "./reducers/RootReducer";

@NgModule({
    imports: [
      BrowserModule,
      HttpModule,
      ROUTER_MODULE
    ],
    providers: [
      AUTH_PROVIDERS,
      JwtHelper,
      // provide(APP_BASE_HREF, {useValue : '/' }),
      provideStore(root),
      AuthService,
      ProfileGuardService      
    ],
    declarations: [
      // components
      AppComponent,
      HomeComponent,
      AboutComponent,
      NewsComponent,
      ProjectsComponent,
      PaymentsComponent,
      HeaderComponent,
      FooterComponent,
      SignInComponent,
      SignUpComponent,
      AuthComponent,
      ProfileComponent

      // directives
    ],
    bootstrap: [ AppComponent ]
})
export class AppModule {}

import { NgModule, provide } from '@angular/core';
import { BrowserModule  } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { provideStore } from "@ngrx/store";
import { ROUTER_MODULE } from "./app.routes";

import { ROUTER_DIRECTIVES, RouterModule,  } from '@angular/router';
import { HTTP_PROVIDERS } from "@angular/http";
import { AUTH_PROVIDERS, JwtHelper } from "angular2-jwt";
import {APP_BASE_HREF} from '@angular/common';

import HomeComponent from "./components/home/HomeComponent";
import AboutComponent from "./components/about/AboutComponent";
import NewsComponent from "./components/news/NewsComponent";
import ProjectsComponent from "./components/projects/ProjectsComponent";
import PaymentsComponent from "./components/payments/PaymentsComponent";
import HeaderComponent from "./components/shared/header/HeaderComponent";
import FooterComponent from "./components/shared/footer/FooterComponent";
import SignInComponent from "./components/authorization/signIn/SignInComponent";
import SignUpComponent from "./components/authorization/signUp/SignUpComponent";

import ProfileGuardService from "./components/authorization/profile/ProfileGuardService";
import AuthService from "./components/authorization/AuthService";

import { root } from "./reducers/RootReducer";



@NgModule({
    declarations: [
      AppComponent,
      HomeComponent,
      AboutComponent,
      NewsComponent,
      ProjectsComponent,
      PaymentsComponent,
      HeaderComponent,
      FooterComponent,
      SignInComponent,
      SignUpComponent
    ],
    imports: [
      BrowserModule,
      ROUTER_MODULE
      // RouterModule,
    ],
    providers: [
      HTTP_PROVIDERS,
      AUTH_PROVIDERS,
      JwtHelper,
      ProfileGuardService,
      AuthService,
      provide(APP_BASE_HREF, {useValue : '/' }),
      provideStore(root)
    ],
    bootstrap:    [AppComponent]
})
export class AppModule {}

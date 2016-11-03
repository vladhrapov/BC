import { Component, OnInit } from "@angular/core";
import { Router } from '@angular/router';
import { Store } from "@ngrx/store";


import AuthService from "../../authorization/AuthService";
import SignInComponent from "../../authorization/signIn/SignInComponent";
import SignUpComponent from "../../authorization/signUp/SignUpComponent";

@Component({
  selector: "[bcAuth]",
  inputs: [
    "isAuthorized"
  ],
  // directives: [
  //     ROUTER_DIRECTIVES
  // ],
  template: `
              <div *ngIf="!isAuthorized">
                <button type="button" class="btn btn-default" [routerLink]="['sign-in']">Sign In</button>
                <button type="button" class="btn btn-default" [routerLink]="['sign-up']">Sign Up</button>
              </div>
              <div *ngIf="isAuthorized">
                <button type="button" class="btn btn-default" [routerLink]="['profile']">Profile</button>
                <button type="button" class="btn btn-default" (click)="signOut()">Sign Out</button>
              </div>
            `
})
export default class AuthComponent implements OnInit {
  // @Input() isAuthorized: boolean;

  constructor(
    private _authService: AuthService,
    private _router: Router,
    private _store: Store<any>
  ) {

  }

  ngOnInit() {
    console.log(this._router, " - ");
  }

  signOut() {
    console.log("345t4grgf");

    window.localStorage.removeItem("token");

    if (this._router.url == "/profile") {
      this._router.navigate(["/"]);
    }

    this._store.dispatch({ type: "LOGGED_OUT", payload: {
      isAuthorized: this._authService.checkAuthorization()
    }});
  }


}

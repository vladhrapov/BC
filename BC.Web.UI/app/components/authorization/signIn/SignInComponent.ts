import { Component, Output, EventEmitter } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "@ngrx/store";

// Services
import AuthService from "../AuthService";

@Component({
  selector: "[bcSignIn]",
  template: `
                <h2>Sign In</h2>
                <div class="form-group">
                    <label for="formGroupExampleInput">Username/Email</label>
                    <input type="text" class="form-control" id="username" placeholder="Enter email or username">
                </div>
                <div class="form-group">
                    <label for="formGroupExampleInput2">Password</label>
                    <input type="password" class="form-control" id="password" placeholder="Enter password">
                </div>
                <button type="button" (click)="signIn()">SignIn</button>
                <button type="button" (click)="getProjects()">getProjects</button>

            `
})
export default class SignInComponent {
  public token: any;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _store: Store<any>
  ) {
    this._store.dispatch({ type: "LOGGED_IN", payload: {
      isAuthorized: this._authService.checkAuthorization()
    }});
  }

  signIn() {
    this._authService
      .getToken((<HTMLInputElement>document.getElementById("username")).value, (<HTMLInputElement>document.getElementById("password")).value)
      .subscribe(
        token => this.token = token,
        error => console.log(error),
        () => {
          console.log('Request Complete', "token: ", this.token, " Token decoded: ", this._authService.decodeToken(this.token.access_token));
          window.localStorage.setItem("token", JSON.stringify(this.token));

          this._store.dispatch({ type: "LOGGED_IN", payload: {
            isAuthorized: this._authService.checkAuthorization()
          }});

          this._router.navigate(["/"]);
        }
      );
  }

}

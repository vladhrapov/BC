import { Component } from "@angular/core";
import { Router } from "@angular/router";

// Services
import AuthService from "../AuthService";

@Component({
  selector: "[bcSignUp]",
  template: `
              <h2>Sign Up</h2>
              <div class="form-group">
                  <label for="formGroupExampleInput">Username</label>
                  <input type="text" class="form-control" id="username" placeholder="Enter username">
              </div>
              <div class="form-group">
                  <label for="formGroupExampleInput">Email</label>
                  <input type="text" class="form-control" id="email" placeholder="Enter email">
              </div>
              <div class="form-group">
                  <label for="formGroupExampleInput">First Name</label>
                  <input type="text" class="form-control" id="firstName" placeholder="Enter first name">
              </div>
              <div class="form-group">
                  <label for="formGroupExampleInput">Last Name</label>
                  <input type="text" class="form-control" id="lastName" placeholder="Enter last name">
              </div>
              <div class="form-group">
                  <label for="formGroupExampleInput2">Password</label>
                  <input type="password" class="form-control" id="password" placeholder="Enter password">
              </div>
              <div class="form-group">
                  <label for="formGroupExampleInput2">Confirm Password</label>
                  <input type="password" class="form-control" id="confirmPassword" placeholder="Confirm password">
              </div>
              <button type="button" (click)="signUp()">SignUp</button>
            `
})
export default class SignUpComponent {
  constructor(
    private _router: Router,
    private _authService: AuthService
  ) { }

  signUp() {
    let username = (<HTMLInputElement>document.getElementById("username")).value;
    let email = (<HTMLInputElement>document.getElementById("email")).value;
    let firstName = (<HTMLInputElement>document.getElementById("firstName")).value;
    let lastName = (<HTMLInputElement>document.getElementById("lastName")).value;
    let password = (<HTMLInputElement>document.getElementById("password")).value;
    

    console.log(username, " ", email, " ", firstName, " ", lastName, " ", password);
    this._authService
      .registerNewUser(username, email, firstName, lastName, password)
      .subscribe(
        data => console.log("data: ", data),
        error => console.log(error),
        () => {
          this._router.navigate(["/sign-in"]);
          //console.log('Request Complete', "token: ", this.token, " Token decoded: ", this._authService.decodeToken(this.token.access_token));
        }
      );
  }

}

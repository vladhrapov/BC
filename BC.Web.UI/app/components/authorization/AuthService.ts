import { Injectable } from "@angular/core";
import { Http, Request, Response, Headers } from "@angular/http";
import { Observable } from 'rxjs/Rx';
import { AuthHttp, AuthConfig, JwtHelper } from 'angular2-jwt';

// Declarations
import { ITokenObject } from "../../declarations/Auth";

@Injectable()
export default class AuthService {
    constructor(
      private _http: Http,
      private _authHttp: AuthHttp,
      private _jwtHelper: JwtHelper
    ) {}

    getToken(username: string, password: string) {
      let hdrs = new Headers();
      hdrs.append("Accept", "application/json");
      hdrs.append('Content-Type', 'application/x-www-form-urlencoded');

    // Pass it after the body in a POST request
    return this._http
        .post(
          "oauth/token",
          // "username=vladyslav_khraps&password=vk2016%24%26&grant_type=\"password\"",
          'username=' + encodeURIComponent(username) + '&password=' + encodeURIComponent(password) + '&grant_type=password',
          // JSON.stringify({username: username, password: password, grant_type: "password"}),
          // `{ "username": "${username}", "password": "${password}", "grant_type": "password"}`,
          { headers: hdrs }
        )
        .map((response: Response) => {
          return response.json();
        })
        .catch(this.handleError);

    }

    checkAuthorization(): boolean {
      let token: ITokenObject,
          tokenString = window.localStorage.getItem("token");

      if (tokenString) {
        token = this._jwtHelper.decodeToken(JSON.parse(tokenString).access_token);
        return !!(token.name && token.surname && token.email);
      }

      return false;
    }

    registerNewUser(username: string, email: string, firstName: string, lastName: string, password: string) {
      let hdrs = new Headers();
      hdrs.append("Accept", "application/json");
      hdrs.append('Content-Type', 'application/json');

      // Pass it after the body in a POST request
      return this._http
        .post(
          "api/accounts/create",
          // "username=vladyslav_khraps&password=vk2016%24%26&grant_type=\"password\"",
          // 'username=' + encodeURIComponent(username) + '&password=' + encodeURIComponent(password) + '&grant_type=password',
          JSON.stringify({Username: username, Email: email, FirstName: firstName, LastName: lastName, Password: password, ConfirmPassword: password}),
          // `{ "username": "${username}", "password": "${password}", "grant_type": "password"}`,
          { headers: hdrs }
        )
        .map((response: Response) => {
          console.log("response after user created: ", response);
          //return response.json();
        })
        .catch(this.handleError);
    }

    decodeToken(token: string): ITokenObject {
      return <ITokenObject>this._jwtHelper.decodeToken(token);
    }

    handleError(error: Response) {
      console.log(error);
      return Observable.throw(error.json().error || "Server error");
    }
}



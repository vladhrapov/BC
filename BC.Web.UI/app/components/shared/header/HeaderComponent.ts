import { Component } from "@angular/core";
import { ROUTER_DIRECTIVES } from '@angular/router';
import { Store } from "@ngrx/store";

import AuthComponent from "./AuthComponent";
import AuthService from "../../authorization/AuthService";

@Component({
  selector: "bc-header",
  directives: [
    ROUTER_DIRECTIVES,
    AuthComponent
  ],
  template: `
              <header>
                <nav class="navbar navbar-default">
                  <div class="container-fluid">

                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">

                      <div class="row-wrapper clearfix">
                        <ul class="nav navbar-nav">
                          <li routerLinkActive="active"><a href="" routerLink="">Home</a></li>
                          <li routerLinkActive="active"><a href="" routerLink="/about">About</a></li>
                          <li routerLinkActive="active"><a href="" routerLink="/news">News</a></li>
                          <li routerLinkActive="active"><a href="" routerLink="/projects">Projects</a></li>
                          <li routerLinkActive="active"><a href="" routerLink="/payments">Payments</a></li>
                        </ul>

                        <ul class="nav navbar-nav navbar-right">
                          <li><a href="#">укр</a></li>
                          <li><a href="#">рус</a></li>
                        </ul>

                        <form class="navbar-form navbar-right" role="search">
                          <div class="form-group">
                            <input type="text" class="form-control" placeholder="Search">
                          </div>
                          <button type="submit" class="btn btn-default">Submit</button>
                          <div class="" bcAuth [isAuthorized]="isAuthorized"></div>
                        </form>
                      </div>

                    </div>
                  </div>

                  <div class="row-wrapper clearfix">
                    <div class="navbar-header">
                      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                      </button>
                      <a class="navbar-brand" href="#">Brand</a>
                    </div>
                  </div>
                </nav>


              </header>
            `,
  styles: [
    `
      .row-wrapper {
        max-width: 960px;
        margin: 0 auto;
      }
    `
  ]

  // template: `
  //             <header>
  //               <nav class="navbar navbar-default">
  //                 <ul class="container">
  //                   <li><a href="" [routerLink]="['Home']">Home</a></li>
  //                   <li><a href="" [routerLink]="['About']">About</a></li>
  //                   <li><a href="" [routerLink]="['News']">News</a></li>
  //                   <li><a href="" [routerLink]="['Projects']">Projects</a></li>
  //                   <li><a href="" [routerLink]="['Payments']">Payments</a></li>
  //                 </ul>
  //               </nav>
  //             </header>
  //           `
})
export default class HeaderComponent {
  public isAuthorized: boolean;

  constructor(
    private _authService: AuthService,
    private _store: Store<any>
  ) {

    ///subscribe to isAuthorized
    this._store.select("authorization").subscribe(payload => {
      console.log("isAuthorized param: ", payload);
      this.isAuthorized = this._authService.checkAuthorization();
    });
  }



}

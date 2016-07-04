import { Component } from "angular2/core";
import { ROUTER_DIRECTIVES } from 'angular2/router';

@Component({
  selector: "bc-header",
  directives: [ROUTER_DIRECTIVES],
  template: `
              <header>
                <nav class="navbar navbar-default">
                  <div class="container-fluid">

                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    
                      <div class="row-wrapper clearfix">
                        <ul class="nav navbar-nav">
                          <li class="active"><a href="" [routerLink]="['Home']">Home</a></li>
                          <li><a href="" [routerLink]="['About']">About</a></li>
                          <li><a href="" [routerLink]="['News']">News</a></li>
                          <li><a href="" [routerLink]="['Projects']">Projects</a></li>
                          <li><a href="" [routerLink]="['Payments']">Payments</a></li>
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
  constructor() {

  }
}

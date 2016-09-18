import { Component } from "@angular/core";

@Component({
  selector: "bc-home",
  template: `
              <div>
                This is Home page
                <p *ngFor="let k of arr">
                  {{k}}
                </p>
              </div>
            `
})
export default class HomeComponent {
  public arr: Array<number>;

  constructor() {
    this.arr = new Array<number>();
    this.init();
  }

  init() {
    console.log(this.arr);

    for (var i = 0; i < 50; i++) {
      this.arr.push(i);
    }
  }
}

import { Injectable } from "@angular/core";
import { Http, Request, Response, Headers } from "@angular/http";
import { Observable } from 'rxjs/Rx';

@Injectable()
export default class ProjectsService {
    constructor(
        private _http: Http
    ) {}

    getProjects() {
      return this._http
        .get("api/Project")
        .map((response: Response) => {
          return response.json();
        });
    }
}
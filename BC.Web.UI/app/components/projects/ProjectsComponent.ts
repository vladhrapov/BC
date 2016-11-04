import { Component } from "@angular/core";

// Services
import ProjectsService from "./ProjectsService";

@Component({
  selector: "bc-projects",
  providers: [
    ProjectsService
  ],
  template: `
              <div>
                Take a look on your projects
              </div>
            `
})
export default class ProjectsComponent {
  public proj: any;

  constructor(
    private _projectsService: ProjectsService
  ) {}

  getProjects() {
    this._projectsService
      .getProjects()
      .subscribe(
        proj => this.proj = proj,
        error => console.log(error),
        () => console.log('Request Complete', "projects: ", this.proj)
      );
  }
}

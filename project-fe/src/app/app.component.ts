import { Component } from '@angular/core';
import {Project} from "./models/project.model";
import {ApiService} from "./api.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'project-fe';
  projects: Project[] = [];

  constructor(private apiService: ApiService) {
    this.apiService.getAllProjects().subscribe({
      next: (projects) => { this.projects = projects; },
      error: (error: any) => { console.log(error); },
      complete: () => { console.log('complete');
      }
    });
  }
}

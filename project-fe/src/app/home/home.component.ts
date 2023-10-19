import { Component } from '@angular/core';
import {Project} from "../models/project.model";
import {ApiService} from "../api.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  title = 'project-fe';
  projects: Project[] = [];

  constructor(private apiService: ApiService, private router: Router) {
    this.apiService.getAllProjects().subscribe({
      next: (projects) => { this.projects = projects; },
      error: (error: any) => { console.log(error); },
      complete: () => { console.log('complete');
      }
    });
  }

  onAddProjectClick() {
    this.router.navigate(['add'], {});
  }
}

import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {Project} from "./models/project.model";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl: string = 'https://localhost:7241/api';

  constructor(private http: HttpClient) { }

  getAllProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl + '/Project');
  }
}

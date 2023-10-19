import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {Project} from "./models/project.model";
import {HttpClient} from "@angular/common/http";
import {Country} from "./models/country.model";

export interface ApiResponse {
  error: boolean;
  msg: string;
  data: Country[];
}

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl: string = 'https://localhost:7241/api';
  externalApiUrl: string = 'https://countriesnow.space/api/v0.1/countries/states';

  constructor(private http: HttpClient) { }

  getAllProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl + '/Project');
  }

  getAllCountries(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(this.externalApiUrl);
  }

  createProject(countryId: number, projectName: string): Observable<Project> {
    return this.http.post<Project>(this.apiUrl + '/Project', {countryId: countryId, projectName: projectName});
  }
}

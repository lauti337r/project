import { Component } from '@angular/core';
import {ApiService} from "../api.service";
import {Country} from "../models/country.model";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.scss']
})
export class AddProjectComponent {
  countries: Country[] = [];
  form: FormGroup = this.formBuilder.group({
    countryId: [0, [Validators.required]],
    projectName: ['', [Validators.required]]});

  constructor(private apiService: ApiService, private formBuilder: FormBuilder) {
    this.apiService.getAllCountries().subscribe({
      next: (countries) => { this.countries = countries.data; },
      error: (error: any) => { console.log(error); },
      complete: () => { console.log('complete'); }
    });
  }

  onCreateProjectClick() {
    this.apiService.createProject(this.form.value.countryId, this.form.value.projectName).subscribe({
      next: (project) => { console.log(project); },
      error: (error: any) => { console.log(error); },
      complete: () => { console.log('complete'); }
    });
  }

  getFormControl(controlName: string) {
    return this.form.get(controlName) as FormControl;
  }
}

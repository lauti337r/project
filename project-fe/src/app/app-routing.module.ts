import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AddProjectComponent} from "./add-project/add-project.component";
import {HomeComponent} from "./home/home.component";

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'add', component: AddProjectComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

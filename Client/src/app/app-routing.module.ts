import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddChildComponent } from './add-child/add-child.component';
import { FormUserComponent } from './form-user/form-user.component';
import { GuidanceComponent } from './guidance/guidance.component';



const routes: Routes = [
  {
    path: "User", component: FormUserComponent
  },
  { path: "Guidance", component: GuidanceComponent },
  { path: "", component: GuidanceComponent },
  { path: "**", component: GuidanceComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

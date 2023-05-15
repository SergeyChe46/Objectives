import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ObjectiveDetailComponent } from './objectives/objective-detail/objective-detail.component';

const routes: Routes = [
  { path: 'detail/:id', component: ObjectiveDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ObjectiveDetailComponent } from './objectives/objective-detail/objective-detail.component';
import { ObjectivesListComponent } from './objectives/objectives-list/objectives-list.component';
import { PerformersListComponent } from './performers/performers-list/performers-list.component';

const routes: Routes = [
  { path: '', component: ObjectivesListComponent },
  { path: 'performers', component: PerformersListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

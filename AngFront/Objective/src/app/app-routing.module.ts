import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ObjectivesListComponent } from './objectives/objectives-list/objectives-list.component';
import { PerformersListComponent } from './performers/performers-list/performers-list.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  { path: '', component: ObjectivesListComponent },
  { path: 'performers', component: PerformersListComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

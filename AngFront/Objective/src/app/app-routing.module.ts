import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ObjectivesListComponent } from './objectives/objectives-list/objectives-list.component';
import { PerformersListComponent } from './performers/performers-list/performers-list.component';
import { PerformerCardComponent } from './performers/performer-card/performer-card.component';

const routes: Routes = [
  { path: '', component: ObjectivesListComponent },
  { path: 'performers', component: PerformersListComponent },
  { path: 'performers/:email', component: PerformerCardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ObjectivesListComponent } from './objectives/objectives-list/objectives-list.component';
import { ObjectiveDetailComponent } from './objectives/objective-detail/objective-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { CreateObjectiveComponent } from './objectives/create-objective/create-objective.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PerformersListComponent } from './performers/performers-list/performers-list.component';
import { PerformersDetailComponent } from './performers/performers-detail/performers-detail.component';
import { PerformerCardComponent } from './performers/performer-card/performer-card.component';
@NgModule({
  declarations: [
    AppComponent,
    ObjectivesListComponent,
    ObjectiveDetailComponent,
    CreateObjectiveComponent,
    PerformersListComponent,
    PerformersDetailComponent,
    PerformerCardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

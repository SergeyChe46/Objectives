import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ObjectivesListComponent } from './objectives/objectives-list/objectives-list.component';
import { ObjectiveDetailComponent } from './objectives/objective-detail/objective-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { CreateObjectiveComponent } from './objectives/create-objective/create-objective.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    ObjectivesListComponent,
    ObjectiveDetailComponent,
    CreateObjectiveComponent,
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

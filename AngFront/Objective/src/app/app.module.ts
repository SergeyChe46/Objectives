import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ObjectivesListComponent } from './objectives/objectives-list/objectives-list.component';
import { ObjectiveDetailComponent } from './objectives/objective-detail/objective-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    ObjectivesListComponent,
    ObjectiveDetailComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

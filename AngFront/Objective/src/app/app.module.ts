import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from '@auth0/angular-jwt';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ObjectivesListComponent } from './objectives/objectives-list/objectives-list.component';
import { ObjectiveDetailComponent } from './objectives/objective-detail/objective-detail.component';
import { HttpClientModule } from '@angular/common/http';
import CreateObjectiveComponent from './objectives/create-objective/create-objective.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PerformersListComponent } from './performers/performers-list/performers-list.component';
import { PerformersDetailComponent } from './performers/performers-detail/performers-detail.component';
import { PerformerCardComponent } from './performers/performer-card/performer-card.component';
import { LoginComponent } from './performers/login/login.component';
import { AuthGuard } from './auth.guard';

export function tokenGetter() { 
  return localStorage.getItem("jwt"); 
}

@NgModule({
  declarations: [
    AppComponent,
    ObjectivesListComponent,
    ObjectiveDetailComponent,
    CreateObjectiveComponent,
    PerformersListComponent,
    PerformersDetailComponent,
    PerformerCardComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5001"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms'; 
import { ObjectivesModule } from './src/app/objectives/objectives.module';
import { ConvertToSpace } from './convertToSpace.pipe';
import { HttpClientModule } from '@angular/common/http'

@NgModule({
  declarations: [
    AppComponent,
    ConvertToSpace
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ObjectivesModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

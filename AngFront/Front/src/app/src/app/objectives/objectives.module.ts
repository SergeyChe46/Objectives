import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ObjectiveListComponent } from './objective-list/components/objective-list.component';
import { FormsModule } from '@angular/forms';
import { StarsComponent } from './objective-list/components/stars.component';



@NgModule({
  declarations: [
    ObjectiveListComponent,
    StarsComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    ObjectiveListComponent,
  ]
})
export class ObjectivesModule { }

import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ObjectiveService } from '../objective-service.service';
import { Objective } from '../objective';

@Component({
  selector: 'app-objectives-list',
  templateUrl: './objectives-list.component.html',
  styleUrls: ['./objectives-list.component.css']
})
export class ObjectivesListComponent {
  constructor(private objService: ObjectiveService){}

  @Input() currentObjective: Objective | undefined;
  @Output() objEmitter = new EventEmitter<Objective>();

  sendToDetailComponent(obj: Objective): void {
    this.currentObjective = obj;
    this.objEmitter.emit(this.currentObjective);
  }
  objectives: Objective[] = this.objService.getObjectives;
}

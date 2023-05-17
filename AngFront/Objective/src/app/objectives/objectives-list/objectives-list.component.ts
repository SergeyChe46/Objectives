import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ObjectiveService } from '../objective-service.service';
import { Objective } from '../objective.interface';

@Component({
  selector: 'app-objectives-list',
  templateUrl: './objectives-list.component.html'
})
export class ObjectivesListComponent implements OnInit {
  constructor(private objService: ObjectiveService){}

  objectives: Objective[] = [];
  thisObjective: Objective | undefined;
  ngOnInit(){
    this.loadObjectives();
  }

  loadObjectives(){
    this.objService.getObjectives()
      .subscribe(data => this.objectives = data);
  }

  sendSelectedObjective(selectedObj: Objective): void {
    this.thisObjective = selectedObj;
  }
}

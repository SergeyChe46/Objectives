import { Component, Input, Output } from '@angular/core';
import { Objective } from '../objective.interface';
import { ObjectiveService } from '../objective.service';

@Component({
  selector: 'app-objective-detail',
  templateUrl: './objective-detail.component.html'
})
export class ObjectiveDetailComponent {

  constructor(private service: ObjectiveService) { }

  @Input() currentObjective: Objective | undefined;

  setSelectObj(obj: Objective): void{
    this.currentObjective = obj;
  }
}

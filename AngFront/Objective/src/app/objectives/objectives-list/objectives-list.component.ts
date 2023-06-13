import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ObjectiveService, ServiceOf } from '../objective.service';
import { Objective } from '../objective.interface';

@Component({
  selector: 'app-objectives-list',
  templateUrl: './objectives-list.component.html'
})
export class ObjectivesListComponent implements OnInit {
  constructor(private service: ObjectiveService) { }

  objectives: Objective[] = [];
  thisObjective: Objective | undefined;
  private _currentPage: number = 5;
  private _currentPageCapacity: number = 5;

  public set currentPage(newValue: number) {
    if (newValue < 1) {
      newValue = 1;
    }
    this._currentPage = newValue;
  }
  public get currentPage(): number {
    return this._currentPage;
  }

  public set currentPageCapacity(newCapacity: number) {
    if (newCapacity < 1) {
      newCapacity = 5;
    }
    this._currentPageCapacity = newCapacity;
  }
  public get currentPageCapacity(): number {
    return this._currentPageCapacity;
  }

  ngOnInit(){
    this.loadObjectives();
  }

  loadObjectives(){
    this.service.getAll(this.currentPage, this.currentPageCapacity)
      .subscribe(data => this.objectives = data);
  }

  sendSelectedObjective(selectedObj: Objective): void {
    this.thisObjective = selectedObj;
  }
}

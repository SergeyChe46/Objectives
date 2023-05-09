import { Component, OnDestroy, OnInit } from '@angular/core';
import { ObjectiveView } from '../../../shared/objective-view.interface';
import { ObjectiveService } from '../../objectives.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'pm-app-objective-list',
  templateUrl: './objective-list.component.html'
})
export class ObjectiveListComponent implements OnInit, OnDestroy {
  constructor(private objs: ObjectiveService) { }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
  
  sub: Subscription;
  errorMessage: string = '';
  pageTitle: string;

  filteredObjs: ObjectiveView[];
  objectives: ObjectiveView[];
  
  ngOnInit(): void {
    this.objectives = this.objs.getProducts();
    this.filteredObjs = this.objectives;
  }

  private _filter: string;

  public get filter(): string {
    return this._filter;
  }

  public set filter(value: string) {
    this._filter = value;
    console.log(this._filter)
    this.filteredObjs = this.performFilter(value);
  }

  performFilter(filterBy: string): ObjectiveView[]{
    filterBy = filterBy.toLocaleLowerCase();
    return this.objectives.filter((obj: ObjectiveView) =>
      obj.title.toLocaleLowerCase().includes(filterBy));
  }
  
  onNotify(message: string): void {
    this.pageTitle = 'Was clicked ' + message + `${Number(message) > 1 ? ' stars' : ' star'}`;
  }
}

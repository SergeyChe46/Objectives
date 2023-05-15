import { Injectable } from '@angular/core';
import { Objective } from './objective';

@Injectable({
  providedIn: 'root'
})
export class ObjectiveService {
  private objectives: Objective[] = [
    {id: 1, title: 'First', description: 'First Description', coworkers: undefined},
    {id: 2, title: 'Second', description: 'Second Description', coworkers: undefined},
    {id: 3, title: 'Third', description: 'Third Description', coworkers: undefined},
    {id: 4, title: 'Fourth', description: 'Fourth Description', coworkers: undefined},
    {id: 5, title: 'Fifth', description: 'Fifth Description', coworkers: undefined},
    {id: 6, title: 'Sixth', description: 'Sixth Description', coworkers: [1]}
  ]
  
  public get getObjectives() : Objective[] {
    return this.objectives;
  }

  
  public set objective(v : Objective) {
    this.objectives.push(v);
  }
}

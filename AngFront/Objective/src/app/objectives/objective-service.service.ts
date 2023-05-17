import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Objective } from './objective.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ObjectiveService {
  
  constructor(private _httpService: HttpClient) { }
  
  accessPointUrl: string = 'http://localhost:5292/api/Objectives/';

  getObjectives(): Observable<Objective[]> {
    return this._httpService.get<Objective[]>(this.accessPointUrl + 'all');
  }

  getObjective(id: number): Observable<Objective> {
    return this._httpService.get<Objective>(this.accessPointUrl + '/' + id);
  }

  postObjective(newObjective: Objective): Observable<Objective> {
    //const body = {title: newObjective.title, desciption: newObjective.description, priority: newObjective.priority};
    return this._httpService.post<Objective>(this.accessPointUrl + 'createObjective', newObjective);
  }
}

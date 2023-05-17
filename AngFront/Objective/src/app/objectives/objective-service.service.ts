import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Objective } from './objective.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ObjectiveService {
  
  constructor(private _httpService: HttpClient) { }
  
  accessPointUrl: string = 'http://localhost:5292/api/Objectives/all';

  getObjectives(): Observable<Objective[]> {
    return this._httpService.get<Objective[]>(this.accessPointUrl);
  }

  getObjective(id: number): Observable<Objective> {
    return this._httpService.get<Objective>(this.accessPointUrl + '/' + id);
  }
}

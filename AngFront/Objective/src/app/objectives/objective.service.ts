import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceOf } from '../../service-of.service';
import { Objective } from './objective.interface';

@Injectable({
  providedIn: 'root'
})
export class ObjectiveService implements ServiceOf<Objective> {
  private readonly baseUrl: string = 'http://localhost:5292/Objectives'; 

  constructor(private http: HttpClient) { }

  getAll(page: number | undefined, pageCapcity: number | undefined): Observable<Objective[]> {
    return this.http.get<Objective[]>(this.baseUrl);
  }
  getOne(id: string): Observable<Objective> {
    return this.http.get<Objective>(this.baseUrl + 'objective/' + id);
  }
  post(created: Objective): Observable<Objective> {
    return this.http.post<Objective>(this.baseUrl, created);
  }
}

export { ServiceOf };

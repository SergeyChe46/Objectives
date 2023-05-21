import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Performers } from '../objectives/performers.interface';

@Injectable({
  providedIn: 'root'
})
export class PerformersService {

  private accessUrl = 'http://localhost:5292/api/Performers/';

  constructor(private http: HttpClient) { }

  getPerformers(): Observable<Performers[]>{
    return this.http.get<Performers[]>(this.accessUrl + 'allPerfs');
  }
}

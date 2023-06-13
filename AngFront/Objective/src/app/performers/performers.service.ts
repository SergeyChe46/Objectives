import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Performers } from './performers.interface';

@Injectable({
  providedIn: 'root'
})
export class PerformersService {

  private accessUrl = 'http://localhost:5292/api/Performers';

  constructor(private http: HttpClient) { }
  /**
   * Возвращает исполнителей из базы данных.
   * @returns Все исполнители.
   */
  getPerformers(): Observable<Performers[]>{
    return this.http.get<Performers[]>(this.accessUrl + '/allPerfs');
  }
  /**
   * Возвращает исполнителя с заданным Id. 
   * @param email Email исполнителя.
   * @returns Исполнителя с заданным Email.
   */
  getPerformer(email: string): Observable<Performers>{
    return this.http.get<Performers>(this.accessUrl + '/' + email);
  }
}

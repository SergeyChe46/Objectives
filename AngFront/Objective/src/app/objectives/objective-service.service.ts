import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Objective } from './objective.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ObjectiveService {
  
  constructor(private _httpService: HttpClient) { }
  
  private accessPointUrl: string = 'http://localhost:5292/api/Objectives/';

  /**
   * Возвращает задачи из базы данных.
   * @returns Задачи из базы данных.
   */
  getObjectives(): Observable<Objective[]> {
    return this._httpService.get<Objective[]>(this.accessPointUrl + 'all');
  }
  /**
   * Возвращает задачу с указанным Id.
   * @param id Id задачи
   * @returns Задача с Id.
   */
  getObjective(id: number): Observable<Objective> {
    return this._httpService.get<Objective>(this.accessPointUrl + '/' + id);
  }
  /**
   * Создаёт новую задачу в базе данных.
   * @param newObjective Задача, полученная из формы.
   * @returns Результат выполнения метода.
   */
  postObjective(newObjective: Objective): Observable<Objective> {
    return this._httpService.post<Objective>(this.accessPointUrl + 'createObjective', newObjective);
  }
}

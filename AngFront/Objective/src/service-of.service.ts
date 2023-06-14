import { Observable } from 'rxjs';

/**
 * @template T тип подставленный в сервис.
 */
export interface ServiceOf<T> {
  /**
   * Возвращает @type {T} из базы данных.
   * @returns @type {T} из базы данных.
   */
  getAll(page: number | undefined, pageCapcity: number | undefined): Observable<T[]>;
  /**
   * Возвращает @type {T} с указанным Id.
   * @param id Id @type {T}
   * @returns @type {T} с Id.
   */
  getOne(id: string): Observable<T>;
  /**
   * Создаёт @type {T} в базе данных.
   * @param newObjective @type {T} полученная из формы.
   * @returns Результат выполнения метода.
   */
  post(created: T): Observable<T>;
}

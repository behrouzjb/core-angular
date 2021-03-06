import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Entity } from './../models/entity';

@Injectable({
  providedIn: 'root'
})
export class EntityService<T extends Entity> {
  constructor(
    private http: HttpClient,
    private url: string,
    private endpoint: string) { }

    public get(params: any[]): Observable<T> {
      return this.http.get<T>(`${this.url}/${this.endpoint}/${params}`);
    }
    public getAll(): Observable<T[]> {
      return this.http.get<T[]>(`${this.url}/${this.endpoint}`);
    }
    public find(params: any[]): Observable<T> {
      return this.http.get<T>(`${this.url}/${this.endpoint}/${params}`);
    }
    public add(item: T): Observable<T> {
      return this.http.post<T>(`${this.url}/${this.endpoint}`, item);
    }
    public update(item: T): Observable<T> {
      return this.http.put<T>(`${this.url}/${this.endpoint}`, item);
    }
    public delete(item: T) {
      return this.http.delete<T>(`${this.url}/${this.endpoint}`, item);
    }
}

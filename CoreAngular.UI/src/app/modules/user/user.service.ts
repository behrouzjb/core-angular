import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EntityService } from 'src/app/shared/services/entity.service';
import { User } from 'src/app/shared/models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService extends EntityService<User> {
  baseUrl = environment.apiUrl;

  constructor() {
    super('user');
  }

  public register(user: User): Observable<any> {
    return this.http.post<User>(`${this.url}/${this.endpoint}/register`, user);
  }

  public login(user: User): Observable<any> {
    return this.http.post<User>(`${this.url}/${this.endpoint}/login`, user);
  }
}

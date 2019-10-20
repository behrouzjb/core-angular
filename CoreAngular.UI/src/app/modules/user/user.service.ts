import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { EntityService } from 'src/app/shared/services/entity.service';
import { User } from 'src/app/shared/models/user';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService extends EntityService<User> {
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;

  constructor() {
    super('user');
  }

  login(user: User): Observable<any> {
    return this.http.post<User>(`${this.url}/${this.endpoint}/login`, user).pipe(
      map((response: any) => {
        const res = response;
        if (user) {
          localStorage.setItem('token', res.token);
          localStorage.setItem('user', JSON.stringify(res.user));
          this.decodedToken = this.jwtHelper.decodeToken(res.token);
          this.currentUser = res.user;
        }
      })
    );
  }

  register(user: User): Observable<any> {
    return this.http.post<User>(`${this.url}/${this.endpoint}/register`, user);
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  getUsers(page?, itemsPerPage?, userParams?, likesParam?): Observable<User[]> {
    let users: User[] = new Array<User>();

    let params = new HttpParams();

    if (userParams != null) {
      params = params.append('orderBy', userParams.orderBy);
    }

    return this.http.get<User[]>(`${this.url}/${this.endpoint}/getUsers`, { observe: 'response', params})
      .pipe(
        map(response => {
          users = response.body;
          return users;
        })
      );
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(`${this.url}/${this.endpoint}/getUsers/${id}`);
  }

  updateUser(user: User): Observable<any> {
    return this.http.put(`${this.url}/${this.endpoint}`, user);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/Rx';
import { JwtHelperService } from '@auth0/angular-jwt';

// Add the RxJS Observable operators we need in this app.
import { BaseService } from './base.service';
import { UserRegistration } from './models/user.registration.interface';
import { Credentials } from './models/credentials.interface';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class UserService extends BaseService {
  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;

  constructor(private http: HttpClient) {
    super();
  }

  getRoles() {
    return this.http.get('/roles');
  }

  login(credentials) {
    return this.http
      .post('/login', credentials)
      .map((res: any) => {
        if (res && res.auth_token) {
          localStorage.setItem('auth_token', res.auth_token);
          this.loggedIn = true;
          this._authNavStatusSource.next(true);
          return true;
        }
        return false;
      })
      .catch(this.handleError);
  }

  register(user): Observable<UserRegistration> {

    return this.http.post('/register', user)
      .map((res: UserRegistration) => res as UserRegistration)
      .catch(this.handleError);
  }

  logout() {
    localStorage.removeItem('auth_token');
  }

  isLoggedIn() {
    const jwtHelper = new JwtHelperService();
    const token = localStorage.getItem('auth_token');

    if (!token) {
      return false;
    }

    const expirationDate = jwtHelper.getTokenExpirationDate(token);
    const isExpired = jwtHelper.isTokenExpired(token);

    return !isExpired;
  }

  get decodedToken() {
    const jwtHelper = new JwtHelperService();
    const token = localStorage.getItem('auth_token');

    if (!token) {
      return false;
    }

    return jwtHelper.decodeToken(token);
  }

}

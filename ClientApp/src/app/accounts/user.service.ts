import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { registerLocaleData } from '@angular/common';
import { BehaviorSubject, Observable } from 'rxjs/Rx';

// Add the RxJS Observable operators we need in this app.
import { BaseService } from './base.service';
import { UserRegistration } from './models/user.registration.interface';
import { Credentials } from './models/credentials.interface';

@Injectable()
export class UserService extends BaseService {
  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;

  constructor(private http: HttpClient) {
    super();
  }

  login(credentials) {
    console.log(credentials);
    return this.http
      .post('/login',credentials
      )
      .map((res: any) => {
        console.log(res);
        localStorage.setItem('auth_token', res.auth_token);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      })
      .catch(this.handleError);
  }

  register(email: string, password: string, firstName: string, lastName: string, location: string): Observable<UserRegistration> {
    let body = JSON.stringify({ email, password, firstName, lastName, location });
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    //  let options = new RequestOptions({ headers: headers });

    return this.http.post("/register", body, {
      headers: headers
    })
      .map(res => true)
      .catch(this.handleError);
  }
}

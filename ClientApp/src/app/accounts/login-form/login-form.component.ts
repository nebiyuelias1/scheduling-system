import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Credentials } from '../models/credentials.interface';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  submitted = false;
  errors: string;
  isRequesting: boolean;
  credentials: Credentials = { email: '', password: '' };
  invalidLogin: boolean;
  brandNew: any;

  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    // subscribe to router event
    this.activatedRoute.queryParams.subscribe(
      (param: any) => {
        this.brandNew = param['brandNew'];
        this.credentials.email = param['email'];
      });
  }

  login({ value, valid }: { value: Credentials, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    if (valid) {
      this.userService.login({ username: value.email, password: value.password })
        .finally(() => this.isRequesting = false)
        .subscribe(
          result => {
            if (result) {
              const returnUrl = this.activatedRoute.snapshot.queryParamMap.get('returnUrl');
              this.router.navigate([ returnUrl || '' ]);
            } else {
              this.invalidLogin = true;
            }
          },
          error => this.errors = error);
    }
  }
}

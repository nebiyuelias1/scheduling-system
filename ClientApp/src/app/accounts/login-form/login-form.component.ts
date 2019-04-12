import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { Credentials } from '../models/credentials.interface';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  submitted: boolean = false;
  errors: string;
  isRequesting: boolean;
  credentials: Credentials = { email: '', password: ''};

  constructor(private userService: UserService, private router: Router) { }
  
  ngOnInit() {
  }

  login({ value, valid }: { value: Credentials, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    if (valid) {
      this.userService.login({username: value.email, password: value.password})
        .finally(() => this.isRequesting = false)
        .subscribe(
          result => {
            if (result) {
              this.router.navigate(['']);
            }
          },
          error => this.errors = error);
    }
  }
}

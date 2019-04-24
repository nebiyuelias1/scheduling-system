import { Component, OnInit } from '@angular/core';
import { UserRegistration } from '../models/user.registration.interface';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-regisration-form',
  templateUrl: './regisration-form.component.html',
  styleUrls: ['./regisration-form.component.css']
})
export class RegisrationFormComponent implements OnInit {
  submitted: boolean;
  isRequesting: boolean;
  errors: any;
  roles: any[];

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.userService.getRoles()
      .subscribe((r: any[]) => this.roles = r);
  }

  registerUser({ value, valid }: { value: UserRegistration, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    if (valid) {
      this.userService.register(value.email, value.password, value.passwordAgain, value.role)
        .finally(() => this.isRequesting = false)
        .subscribe(result => {
          if (result) {
            this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
          }
        },
          errors => this.errors = errors);
    }
  }
}

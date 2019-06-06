import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DepartmentService } from '../services/department.service';
import { InstructorService } from '../services/instructor.service';
import { UserService } from '../accounts/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { UserRegistration } from '../accounts/models/user.registration.interface';

@Component({
  selector: 'app-instructor-form',
  templateUrl: './instructor-form.component.html',
  styleUrls: ['./instructor-form.component.css']
})
export class InstructorFormComponent implements OnInit {
  departments: any[];
  form = new FormGroup({
    user: new FormGroup({
      firstName: new FormControl(),
      fatherName: new FormControl(),
      grandFatherName: new FormControl(),
      email: new FormControl()
    }),
    departmentId: new FormControl()
  });
  id: string;

  constructor(private departmentService: DepartmentService,
    private instructorService: InstructorService,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    const sources = [this.departmentService.getDepartments()];
    this.id = this.route.snapshot.paramMap.get('id');
    if (this.id) {
    }

    this.departmentService.getDepartments()
      .subscribe((result: any[]) => {
        this.departments = result;
      });
  }

  save() {
    if (this.form.valid) {
      const user = this.form.get('user').value;
      user.password = 'P@ssw0rd';
      user.passwordAgain = 'P@ssw0rd';
      user.role = 'Instructor';
      user.departmentId = this.form.get('departmentId').value,

      this.userService.register(user)
      .subscribe((u: UserRegistration) => {
        this.router.navigate(['/instructors']);
      }, err => console.error(err));
    }
  }
}

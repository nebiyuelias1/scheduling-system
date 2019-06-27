import { Component, OnInit } from '@angular/core';
import { CollegeService } from '../services/college.service';
import { FormGroup, FormControl } from '@angular/forms';
import { DepartmentService } from '../services/department.service';
import { UserService } from '../accounts/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-department-form',
  templateUrl: './department-form.component.html',
  styleUrls: ['./department-form.component.css']
})
export class DepartmentFormComponent implements OnInit {
  form = new FormGroup({
    name: new FormControl('')
  });

  constructor(
    private departmentService: DepartmentService,
    private userService: UserService,
    private router: Router) { }

  ngOnInit() {
  }

  save() {
    const dept = this.form.value;
    dept.collegeId = this.userService.decodedToken.coll_id;

    this.departmentService.saveDepartment(dept)
      .subscribe((result) => {
        this.router.navigate(['departments']);
      }, (error) => console.error(error));
  }

}

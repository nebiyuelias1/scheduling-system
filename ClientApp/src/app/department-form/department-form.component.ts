import { Component, OnInit } from '@angular/core';
import { CollegeService } from '../services/college.service';
import { FormGroup, FormControl } from '@angular/forms';
import { DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-department-form',
  templateUrl: './department-form.component.html',
  styleUrls: ['./department-form.component.css']
})
export class DepartmentFormComponent implements OnInit {
  colleges: any[];

  form = new FormGroup({
    collegeId: new FormControl(''),
    name: new FormControl('')
  });

  constructor(
    private collegeService: CollegeService,
    private departmentService: DepartmentService) { }

  ngOnInit() {
    this.collegeService.getColleges().subscribe((result: any[]) => {
      this.colleges = result;
    });
  }

  save() {
    this.departmentService.saveDepartment(this.form.value)
      .subscribe((result) => {
        console.log(result);
      }, (error) => { console.error(error)});
  }

}

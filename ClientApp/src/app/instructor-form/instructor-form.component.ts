import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DepartmentService } from '../services/department.service';
import { InstructorService } from '../services/instructor.service';

@Component({
  selector: 'app-instructor-form',
  templateUrl: './instructor-form.component.html',
  styleUrls: ['./instructor-form.component.css']
})
export class InstructorFormComponent implements OnInit {
  departments: any[];
  form = new FormGroup({
    firstName: new FormControl(),
    fatherName: new FormControl(),
    grandFatherName: new FormControl(),
    departmentId: new FormControl()
  });

  constructor(private departmentService: DepartmentService,
    private instructorService: InstructorService) { }

  ngOnInit() {
    this.departmentService.getDepartments()
      .subscribe((result: any[]) => {
        this.departments = result;
      });
  }

  save() {
    this.instructorService.save(this.form.value)
      .subscribe((result) => console.log(result),
      (error) => console.error(error));
  }

}

import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';
import { Observable } from 'rxjs/Observable';
import { resource } from 'selenium-webdriver/http';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-assign-instructor',
  templateUrl: './assign-instructor.component.html',
  styleUrls: ['./assign-instructor.component.css']
})
export class AssignInstructorComponent implements OnInit {
  types: any[];
  instructors: any[];
  courseOfferingId;

  form = new FormGroup({
    courseOfferingId: new FormControl(),
    instructorId: new FormControl(),
    typeId: new FormControl()
  });

  constructor(private commonService: CommonService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.courseOfferingId = this.activatedRoute.snapshot.paramMap.get('id');
    this.form.controls['courseOfferingId']
    .setValue(this.courseOfferingId);

    this.commonService.getTypes()
      .subscribe((result: any[]) => this.types = result,
      (error) => console.error(error));

    this.commonService.getInstructors()
      .subscribe((result: any[]) => this.instructors = result,
      (error) => console.error(error));
  }

  assignInstructor() {
    this.commonService.assignInstructor(this.form.value)
      .subscribe((result) => console.log(result),
      (error) => console.error(error));
  }
}

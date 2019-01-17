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
    instructorId: new FormControl(),
    typeId: new FormControl()
  });

  constructor(private commonService: CommonService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.courseOfferingId = this.activatedRoute.snapshot.paramMap.get('id');

    this.commonService.getTypes()
      .subscribe((result: any[]) => this.types = result,
      (error) => console.error(error));

    this.commonService.getInstructors()
      .subscribe((result: any[]) => this.instructors = result,
      (error) => console.error(error));
  }

  assignInstructor() {
    console.log(this.courseOfferingId, this.form.value);
  }
}

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

  courseOffering;

  constructor(private commonService: CommonService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    console.log('ngOnInit called.');

    this.courseOfferingId = this.activatedRoute.snapshot.paramMap.get('id');

    this.commonService.getCourseOffering(this.courseOfferingId)
      .subscribe(result => {
        this.courseOffering = result;
        console.log(this.courseOffering);
      });

    // this.commonService.getTypes()
    //   .subscribe((result: any[]) => this.types = result,
    //   (error) => console.error(error));

    // this.commonService.getInstructors()
    //   .subscribe((result: any[]) => this.instructors = result,
    //   (error) => console.error(error));
  }

  assignInstructor() {
    // this.commonService.assignInstructor(this.form.value)
    //   .subscribe((result) => console.log(result),
    //   (error) => console.error(error));
  }

  getLectureInstructor() {
    const instructor = this.courseOffering.instructors
    .filter(i => i.type.id === 1);
  }

  hasLecture() {
    console.log('hasLecture called');
  }

  hasLab() {
  }

  hasTutor() {
  }
}

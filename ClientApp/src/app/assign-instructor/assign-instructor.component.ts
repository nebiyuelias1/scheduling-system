import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
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
  hasLoaded = false;

  constructor(private commonService: CommonService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.courseOfferingId = this.activatedRoute.snapshot.paramMap.get('id');

    this.commonService.getCourseOffering(this.courseOfferingId)
      .subscribe(result => {
        this.courseOffering = result;
        this.hasLoaded = true;
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

  getInstructor(typeId) {
    if (!this.hasLoaded) {
      return '';
    }

    let instructor = this.courseOffering.instructors
      .filter(i => i.type.id === typeId)[0];

    if (!instructor) {
      return '';
    }

    instructor = instructor.instructor;

    return instructor.firstName + ' ' + instructor.fatherName + ' ' + instructor.grandFatherName;
  }

  hasLecture() {
    return this.hasLoaded && this.courseOffering.course.lecture > 0;
  }

  hasLab() {
    return this.hasLoaded && this.courseOffering.course.lab > 0;
  }

  hasTutor() {
    return this.hasLoaded && this.courseOffering.course.tutor > 0;
  }
}

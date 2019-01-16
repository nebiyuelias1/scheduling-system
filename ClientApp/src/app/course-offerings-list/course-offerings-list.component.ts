import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-course-offerings-list',
  templateUrl: './course-offerings-list.component.html',
  styleUrls: ['./course-offerings-list.component.css']
})
export class CourseOfferingsListComponent implements OnInit {
  courseOfferings: any[];

  constructor(private commonService: CommonService) { }

  ngOnInit() {
    this.commonService.getCourseOfferings()
    .subscribe((result: any[]) => {
      this.courseOfferings = result;
      console.log(this.courseOfferings);
    },
    (error) => console.error(error));
  }

  createCourseOfferings() {
    this.commonService.createCourseOfferings()
      .subscribe((result: any[]) => {
        this.courseOfferings = result;
        console.log(this.courseOfferings);
      },
      (error) => console.error(error));
  }
}

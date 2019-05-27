import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { CommonService } from '../services/common.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-assign-instructor',
  templateUrl: './course-offering-detail.component.html',
  styleUrls: ['./course-offering-detail.component.css']
})
export class CourseOfferingDetailComponent implements OnInit {
  types: any[];
  instructors: any[];
  courseOfferingId;

  courseOffering: any = null;

  constructor(private commonService: CommonService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.courseOfferingId = this.activatedRoute.snapshot.paramMap.get('id');

    this.commonService.getCourseOffering(this.courseOfferingId)
      .subscribe((result: any) => {
        this.courseOffering = result;
      });

  }

  assignInstructor() {
  }
}

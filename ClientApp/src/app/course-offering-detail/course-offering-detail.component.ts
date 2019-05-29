import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { CommonService } from '../services/common.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-assign-instructor',
  templateUrl: './course-offering-detail.component.html',
  styleUrls: ['./course-offering-detail.component.css']
})
export class CourseOfferingDetailComponent implements OnInit, OnDestroy {
  types: any[];
  instructors: any[];
  courseOfferingId;

  courseOffering: any = null;
  navigationSubscription: any;

  constructor(private commonService: CommonService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
      this.navigationSubscription = this.router.events.subscribe((e: any) => {
        if (e instanceof NavigationEnd) {
          this.initialize();
        }
      });
    }

  ngOnInit() {
    this.initialize();
  }

  ngOnDestroy(): void {
    if (this.navigationSubscription) {
      this.navigationSubscription.unsubscribe();
    }
  }

  initialize() {
    this.courseOfferingId = this.activatedRoute.snapshot.paramMap.get('id');

    this.commonService.getCourseOffering(this.courseOfferingId)
      .subscribe((result: any) => {
        this.courseOffering = result;
      });
  }
}

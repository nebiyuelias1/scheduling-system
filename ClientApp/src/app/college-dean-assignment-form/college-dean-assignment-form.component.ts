import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InstructorService } from '../services/instructor.service';
import { CollegeService } from '../services/college.service';

@Component({
  selector: 'app-college-dean-assignment-form',
  templateUrl: './college-dean-assignment-form.component.html',
  styleUrls: ['./college-dean-assignment-form.component.css'],
})
export class CollegeDeanAssignmentFormComponent implements OnInit {
  instructors: any;
  id: string;
  instructorId = '';

  constructor(
    private route: ActivatedRoute,
    private instructorService: InstructorService,
    private collegeService: CollegeService,
    private router: Router) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.id) {
      this.instructorService.getInstructors({ collegeId: this.id })
        .subscribe((x: any) => {
          this.instructors = x.items;
        }, err => console.error(err));
    }
  }

  get isDisabled() {
    if (this.instructorId.length > 0) {
      return false;
    }

    return true;
  }

  assign() {
    this.collegeService.assignDean(this.id, this.instructorId)
      .subscribe(() => this.router.navigate(['/colleges']),
      err => console.error(err));
  }
}

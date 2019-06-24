import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InstructorService } from '../services/instructor.service';
import { CollegeService } from '../services/college.service';
import { DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-department-head-assignment-form',
  templateUrl: './department-head-assignment-form.component.html',
  styleUrls: ['./department-head-assignment-form.component.css']
})
export class DepartmentHeadAssignmentFormComponent implements OnInit {
  instructors: any;
  id: string;
  instructorId = '';

  constructor(
    private route: ActivatedRoute,
    private instructorService: InstructorService,
    private departmentService: DepartmentService,
    private router: Router
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.id) {
      this.instructorService.getInstructors({ departmentId: this.id })
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
    this.departmentService.assignHead(this.id, this.instructorId)
      .subscribe(() => this.router.navigate(['/departments']),
      err => console.error(err));
  }
}

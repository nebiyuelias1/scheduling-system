import { Component, OnInit } from '@angular/core';
import { CurriculumService } from '../services/curriculum.service';
import { FormGroup, FormControl } from '@angular/forms';
import { CourseService } from '../services/course.service';
import { SaveCourse } from '../models/save-course-interface';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styleUrls: ['./course-form.component.css']
})
export class CourseFormComponent implements OnInit {
  curriculums: any[];
  course: SaveCourse = {
    id: 0,
    courseCode: '',
    name: '',
    curriculumId: 0,
    deliverySemester: 0,
    deliveryYear: 0,
    lab: 0,
    lecture: 0,
    tutor: 0
  };

  form = new FormGroup({
    name: new FormControl(),
    courseCode: new FormControl(),
    lecture: new FormControl(),
    lab: new FormControl(),
    tutor: new FormControl(),
    curriculumId: new FormControl(),
    deliveryYear: new FormControl(),
    deliverySemester: new FormControl()
  });

  constructor(
    private curriculumService: CurriculumService,
    private courseService: CourseService,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    const query = {
      departmentId: this.userService.decodedToken.dept_id,
    };

    const sources = [this.curriculumService.getCurriculums(query)];

    if (id !== null) {
      sources.push(this.courseService.getCourse(id));
    }

    Observable.forkJoin(sources)
      .subscribe(x => {
        this.curriculums = x[0].items as any[];

        if (id !== null) {
          this.course = x[1] as SaveCourse;
          this.populateForm(this.course);
        }
      });
  }

  submit() {
    const result$ = (this.course.id) ?
      this.courseService.update(this.course.id, this.form.value) :
      this.courseService.saveCourse(this.form.value);

    result$.subscribe(x => {
      this.router.navigate(['/courses']);
    });
  }

  populateForm(courseData: SaveCourse) {
    this.form.patchValue(courseData);
  }
}

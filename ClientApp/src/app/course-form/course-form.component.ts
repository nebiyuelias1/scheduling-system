import { Component, OnInit } from '@angular/core';
import { CurriculumService } from '../services/curriculum.service';
import { FormGroup, FormControl } from '@angular/forms';
import { CourseService } from '../services/course.service';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styleUrls: ['./course-form.component.css']
})
export class CourseFormComponent implements OnInit {
  curriculums: any[];
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
    private courseService: CourseService) { }

  ngOnInit() {
    this.curriculumService.getCurriculums()
      .subscribe((result:any[]) => {
        this.curriculums = result;
      });
  }

  save() {
    this.courseService.saveCourse(this.form.value)
      .subscribe((result) => console.log(result),
        error => console.error(error));
  }

}

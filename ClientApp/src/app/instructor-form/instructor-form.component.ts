import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DepartmentService } from '../services/department.service';
import { InstructorService } from '../services/instructor.service';
import { UserService } from '../accounts/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { UserRegistration } from '../accounts/models/user.registration.interface';
import { Observable } from 'rxjs';
import { SaveInstructor } from '../models/save-instructor-interface';

@Component({
  selector: 'app-instructor-form',
  templateUrl: './instructor-form.component.html',
  styleUrls: ['./instructor-form.component.css']
})
export class InstructorFormComponent implements OnInit {
  departments: any[];
  instructor: SaveInstructor = {
    id: 0,
    firstName: '',
    fatherName: '',
    grandFatherName: '',
    departmentId: 0
  };

  form = new FormGroup({
    user: new FormGroup({
      firstName: new FormControl(),
      fatherName: new FormControl(),
      grandFatherName: new FormControl(),
      email: new FormControl()
    }),
    departmentId: new FormControl()
  });

  constructor(private departmentService: DepartmentService,
    private instructorService: InstructorService,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    const sources = [this.departmentService.getDepartments()];
    const id = this.route.snapshot.paramMap.get('id');

    if (id !== null) {
      sources.push(this.instructorService.getInstructor(id));
    }

    Observable.forkJoin(sources)
      .subscribe((x: any) => {
        this.departments = x[0];

        if (id !== null) {
          this.instructor = x[1];
          this.populateForm(this.instructor);
        }
      });
  }

  submit() {
    let result$;
    if (this.instructor.id) {
      const user = this.form.get('user').value;
      user.departmentId = this.form.get('departmentId').value;
      result$ = this.instructorService.update(this.instructor.id, user);
    } else {
      const user = this.form.get('user').value;
      user.password = 'P@ssw0rd';
      user.passwordAgain = 'P@ssw0rd';
      user.role = 'Instructor';
      user.departmentId = this.form.get('departmentId').value;
      result$ = this.userService.register(user);
    }

    result$.subscribe(x => {
      this.router.navigate(['instructors']);
    });
  }

  populateForm(data) {
    data.departmentId = data.user.departmentId;
    this.form.patchValue(data);
  }
}

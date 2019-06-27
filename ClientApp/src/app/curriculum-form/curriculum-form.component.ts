import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../services/department.service';
import { CurriculumService } from '../services/curriculum.service';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router, NavigationExtras } from '@angular/router';
import { SaveCurriculum } from '../models/save-curriculum-interface';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-curriculum-form',
  templateUrl: './curriculum-form.component.html',
  styleUrls: ['./curriculum-form.component.css']
})
export class CurriculumFormComponent implements OnInit {
  curriculum: SaveCurriculum = {
    id: 0,
    nomenclature: '',
    staySemester: 0,
    stayYear: 0,
    departmentId: 0
  };

  form = new FormGroup({
    nomenclature: new FormControl(''),
    stayYear: new FormControl(''),
    staySemester: new FormControl('')
  });

  constructor(
    private curriculumService: CurriculumService,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id !== null) {
      this.curriculumService.getCurriculum(id)
        .subscribe((result: any) => {
          this.curriculum = result;
          this.form.get('nomenclature').setValue(this.curriculum.nomenclature);
          this.form.get('stayYear').setValue(this.curriculum.stayYear);
          this.form.get('staySemester').setValue(this.curriculum.staySemester);
        });
    }

  }

  save() {
    if (this.curriculum.id === 0) {
      const c = this.form.value;
      c.departmentId = this.userService.decodedToken.dept_id;

      this.curriculumService.save(c)
      .subscribe(() => {
        // this.router.onSameUrlNavigation = 'reload';
        this.router.navigate(['/curriculums']);
      }, error => {
        console.error(error);
      });
    } else {
      this.curriculumService.update(this.curriculum.id, this.form.value)
        .subscribe(() => {
          // this.router.onSameUrlNavigation = 'reload';
          this.router.navigate(['/curriculums']);
        }, error => {
          console.log(error);
        });
    }
  }
}

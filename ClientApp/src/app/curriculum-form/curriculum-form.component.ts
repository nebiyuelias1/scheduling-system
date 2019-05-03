import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../services/department.service';
import { CurriculumService } from '../services/curriculum.service';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { SaveCurriculum } from '../models/save-curriculum-interface';

@Component({
  selector: 'app-curriculum-form',
  templateUrl: './curriculum-form.component.html',
  styleUrls: ['./curriculum-form.component.css']
})
export class CurriculumFormComponent implements OnInit {
  departments: any[];
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
    staySemester: new FormControl(''),
    departmentId: new FormControl('')
  });

  constructor(
    private departmentService: DepartmentService,
    private curriculumService: CurriculumService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id');
    
    this.departmentService.getDepartments()
      .subscribe((result: any[]) => {
        this.departments = result;
      });

    if (id !== null) {
      this.curriculumService.getCurriculum(id)
        .subscribe((result: any) => {
          this.curriculum = result;
          this.form.get('nomenclature').setValue(this.curriculum.nomenclature);
          this.form.get('stayYear').setValue(this.curriculum.stayYear);
          this.form.get('staySemester').setValue(this.curriculum.staySemester);
          this.form.get('departmentId').setValue(this.curriculum.departmentId);
        });
    }

  }

  save() {
    if (this.curriculum.id === 0) {
      this.curriculumService.save(this.form.value)
      .subscribe((result)=> {
        console.log(result);
      }, error => {
        console.error(error);
      });
    } else {
      this.curriculumService.update(this.curriculum.id, this.form.value)
        .subscribe((result)=> {
          this.router.navigate(['/curriculums']);
        }, error => {
          console.log(error);
        });
    } 
  }
}

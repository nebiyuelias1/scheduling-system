import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../services/department.service';
import { CurriculumService } from '../services/curriculum.service';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-curriculum-form',
  templateUrl: './curriculum-form.component.html',
  styleUrls: ['./curriculum-form.component.css']
})
export class CurriculumFormComponent implements OnInit {
  departments: any[];
  form = new FormGroup({
    nomenclature: new FormControl(''),
    stayYear: new FormControl(''),
    staySemester: new FormControl(''),
    departmentId: new FormControl('')
  });

  constructor(
    private departmentService: DepartmentService,
    private curriculumService: CurriculumService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
      this.curriculumService.getCurriculum(id);
    }

    this.departmentService.getDepartments()
      .subscribe((result: any[]) => {
        this.departments = result;
      });
  }

  save() {
    this.curriculumService.save(this.form.value).subscribe((result)=> {
      console.log(result);
    }, error => {
      console.error(error);
    });
  }

}

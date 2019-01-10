import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-academic-semester-form',
  templateUrl: './academic-semester-form.component.html',
  styleUrls: ['./academic-semester-form.component.css']
})
export class AcademicSemesterFormComponent implements OnInit {
  academicYears: any[];
  form = new FormGroup({
    semester: new FormControl(),
    startDate: new FormControl(),
    endDate: new FormControl(),
    academicYearId: new FormControl()
  });

  constructor(private commonService: CommonService) { }

  ngOnInit() {
    this.commonService.getAcademicYears()
      .subscribe((result: any[]) => this.academicYears = result);
  }

  save() {
    this.commonService.saveAcademicSemester(this.form.value)
      .subscribe((result) => console.log(result),
      (error) => console.error(error));
  }

}

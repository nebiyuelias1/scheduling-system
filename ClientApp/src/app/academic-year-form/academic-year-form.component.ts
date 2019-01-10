import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-academic-year-form',
  templateUrl: './academic-year-form.component.html',
  styleUrls: ['./academic-year-form.component.css']
})
export class AcademicYearFormComponent implements OnInit {
  form = new FormGroup({
    gcYear: new FormControl(),
    etYear: new FormControl(),
    startDate: new FormControl(),
    endDate: new FormControl()
  });

  constructor(private commonService: CommonService) { }

  ngOnInit() {
  }

  save() {
    this.commonService.saveAcademicYear(this.form.value)
      .subscribe((result) => console.log(result),
      (error) => console.error(error));
  }
}

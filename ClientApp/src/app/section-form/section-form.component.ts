import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';
import { FormGroup, FormControl } from '@angular/forms';
import { SectionService } from '../services/section.service';

@Component({
  selector: 'app-section-form',
  templateUrl: './section-form.component.html',
  styleUrls: ['./section-form.component.css']
})
export class SectionFormComponent implements OnInit {
  programTypes: any[];
  admissionLevels: any[];
  form = new FormGroup({
    name: new FormControl(),
    entranceYear: new FormControl(),
    studentCount: new FormControl(),
    departmentId: new FormControl(),
    programTypeId: new FormControl(),
    admissionLevelId: new FormControl()
  });

  constructor(private commonService: CommonService,
    private sectionService: SectionService) { }

  ngOnInit() {
    this.commonService.getProgramTypes()
      .subscribe((result: any[]) => this.programTypes = result);

    this.commonService.getAdmissionLevels()
      .subscribe((result: any[]) => this.admissionLevels = result);
  }

  save() {
    this.sectionService.save(this.form.value)
      .subscribe((result) => console.log(result),
      (error) => console.error(error));
  }
}

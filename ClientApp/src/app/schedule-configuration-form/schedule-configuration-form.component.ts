import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-schedule-configuration-form',
  templateUrl: './schedule-configuration-form.component.html',
  styleUrls: ['./schedule-configuration-form.component.css']
})
export class ScheduleConfigurationFormComponent implements OnInit {
  admissionLevels: any[];
  programTypes: any[];
  isThereLunchBreak;
  form = new FormGroup({
    admissionLevelId: new FormControl(),
    programTypeId: new FormControl(),
    numberOfDaysPerWeek: new FormControl(),
    numberOfPeriodsPerDay: new FormControl(),
    startTime: new FormControl(),
    periodDuration: new FormControl(),
    periodBreakDuration: new FormControl(),
    isThereALunchBreak: new FormControl(),
    lunchBreakDuration: new FormControl()
  });

  constructor(private commonService: CommonService) { }

  ngOnInit() {
    this.commonService.getAdmissionLevels()
      .subscribe((result: any[]) => this.admissionLevels = result,
      (error) => console.error(error));

    this.commonService.getProgramTypes()
      .subscribe((result: any[]) => this.programTypes = result,
      (error) => console.error(error));
  }

  save() {
    this.commonService.saveScheduleConfiguration(this.form.value)
      .subscribe((result) => console.log(result),
      error => console.error(error));
  }

  toggleLunchBreak() {
    this.isThereLunchBreak = !this.isThereLunchBreak;
  }

}

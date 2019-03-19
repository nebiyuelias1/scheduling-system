import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {
  schedule;

  constructor(private commonService: CommonService) { }

  ngOnInit() {
  }

  generateSchedule() {
    this.commonService.getTimetable(7)
      .subscribe(s => {
        this.schedule = s;
      },
        err => console.log(err));
  }
}

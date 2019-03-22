import { Component, OnInit, Input } from '@angular/core';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.css']
})
export class TimetableComponent implements OnInit {
  @Input('timetable')
  timetable;
  weekDays;
  periods;

  constructor(private commonService: CommonService) { }

  ngOnInit() {
    this.commonService.getWeekDays()
      .subscribe((w: any[]) => {
        this.weekDays = w.slice(0, this.timetable.scheduleConfiguration.numberOfDaysPerWeek);
      },
        err => console.error(err));
    this.periods = Array(this.timetable.scheduleConfiguration.numberOfPeriodsPerDay).fill(0).map((x, i) => i);
  }

}

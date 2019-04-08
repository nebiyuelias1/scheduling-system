import { Component, OnInit, Input } from '@angular/core';
import { CommonService } from '../services/common.service';
import { FullCalendarOptions, EventObject } from 'ngx-fullcalendar';

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
  options: FullCalendarOptions;
  events: EventObject[];

  constructor(private commonService: CommonService) {
  }

  ngOnInit() {
    this.options = {
      defaultView: 'agendaWeek',
      editable: true,
      titleFormat: 'DD MMMM YYYY',
      columnHeaderFormat: 'dddd',
      header: {
        left: '',
        center: 'dayGridMonth,timeGridWeek',
        right: 'prev,next basicWeek, basicDay, agenda'
      },
      weekends: false,
      allDaySlot: false
    };

    this.events = [
      { id: 'a', title: 'My Birthday', allDay: true },
      { id: 'b', title: 'Friends coming round', start: '2019-04-2T18:00:00', end: '2019-04-5T23:00:00' }
    ];

    this.commonService.getWeekDays()
      .subscribe((w: any[]) => {
        this.weekDays = w.slice(0, this.timetable.scheduleConfiguration.numberOfDaysPerWeek);
      },
        err => console.error(err));
    this.periods = Array(this.timetable.scheduleConfiguration.numberOfPeriodsPerDay).fill(0).map((x, i) => i);
  }

}

import { Component, OnInit, Input, ViewChild } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import * as moment from 'moment';
import { ScheduleConfigurationService } from '../services/schedule-configuration.service';
import { FullCalendarComponent } from '@fullcalendar/angular';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.css']
})
export class TimetableComponent implements OnInit {
  options: any;
  calendarPlugins = [dayGridPlugin, timeGridPlugin];
  @ViewChild('fullcalendar', null) fullcalendar: FullCalendarComponent;
  // tslint:disable-next-line:no-input-rename
  @Input('timetable') timetable;
  // tslint:disable-next-line:no-input-rename
  @Input('sectionId') id;

  timetableEvents = [];
  constructor(private scheduleConfigurationService: ScheduleConfigurationService) { }

  ngOnInit() {
    this.scheduleConfigurationService.getScheduleConfiguration({
      sectionId: this.id,
      onlyClassType: true
    })
      .subscribe(scheduleConfiguration => {
        console.log(scheduleConfiguration);
        for (const day of this.timetable) {
          for (const daySession of day.daySessions) {
            for (const scheduleEntry of daySession.scheduleEntries) {
              const start = scheduleConfiguration
                              .durations[scheduleEntry.period]
                              .startTime
                              .split('T')[1]
                              .split(':');

              const end = scheduleConfiguration
                              .durations[scheduleEntry.period + scheduleEntry.duration - 1]
                              .endTime
                              .split('T')[1]
                              .split(':');

              const e = {
                title: scheduleEntry.course.courseCode,
                description: scheduleEntry.course.name,
                start: moment().weekday(day.weekDay.number + 1).set({
                  hour: parseInt(start[0], 10),
                  minute: parseInt(start[1], 10),
                  second: parseInt(start[2], 10)
                }).format(),
                end: moment().weekday(day.weekDay.number + 1).set({
                  hour: parseInt(end[0], 0),
                  minute: parseInt(end[1], 0),
                  second: parseInt(end[2], 0),
                }).format()
              };
              this.timetableEvents = this.timetableEvents.concat(e);
            }
          }
        }
      });
    this.options = {
      editable: true,
      allDaySlot: false,
      minTime: '02:30:00',
      maxTime: '11:30:00',
      customButtons: {
        myCustomButton: {
          text: 'custom!',
          click: function () {
            alert('clicked the custom button!');
          }
        }
      },
      theme: 'standart', // default view, may be bootstrap
      header: {
        left: 'prev,next today myCustomButton',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay'
      },
      columnHeaderHtml: () => {
          return '<b>Friday!</b>';
      },
      columnHeaderFormat: {
        weekday: 'long'
      },
      // add other plugins
      plugins: [dayGridPlugin, timeGridPlugin ]
    };

  }

}

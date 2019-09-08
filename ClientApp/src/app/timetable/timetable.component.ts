import { Component, OnInit, Input } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import { id } from '@swimlane/ngx-datatable/release/utils';
import { ScheduleConfigurationService } from '../services/schedule-configuration.service';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.css']
})
export class TimetableComponent implements OnInit {
  options: any;
  calendarPlugins = [dayGridPlugin, timeGridPlugin];
  // tslint:disable-next-line:no-input-rename
  @Input('timetable') timetable;
  // tslint:disable-next-line:no-input-rename
  @Input('sectionId') id;

  calendarEvents = [
    { title: 'event-1', date: '2019-04-01' },
    { title: 'event-1', date: '2019-09-05' },
    { title: 'event-2', date: '2019-09-06' }
  ];
  constructor(private scheduleConfigurationService: ScheduleConfigurationService) { }

  ngOnInit() {
    this.scheduleConfigurationService.getScheduleConfiguration(this.id)
      .subscribe(x => {
        console.log(x);
      });
    this.options = {
      editable: true,
      allDaySlot: false,
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

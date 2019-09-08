import { Component, OnInit, ViewChild } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import { FullCalendarComponent } from '@fullcalendar/angular';


@Component({
  selector: 'app-demo-component',
  templateUrl: './demo-component.component.html',
  styleUrls: ['./demo-component.component.css']
})
export class DemoComponentComponent implements OnInit {
  options: any;
  calendarPlugins = [dayGridPlugin, timeGridPlugin]; // important!
  @ViewChild('fullcalendar', null) fullcalendar: FullCalendarComponent;
  calendarEvents = [
    { title: 'event-1', date: '2019-04-01' },
    { title: 'event-1', date: '2019-09-05' },
    { title: 'event-2', date: '2019-09-06' }
  ];
  constructor() { }

  ngOnInit() {
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

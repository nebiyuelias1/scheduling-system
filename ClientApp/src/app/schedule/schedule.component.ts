import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';
import { ActivatedRoute } from '@angular/router';
import { SectionService } from '../services/section.service';
import { ScheduleService } from '../services/schedule.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {
  schedule;
  section: any;

  constructor(
    private commonService: CommonService,
    private scheduleService: ScheduleService,
    private sectionService: SectionService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.sectionService.getSection(+id)
      .subscribe(s => {
        this.section = s;
      }, err => console.error(err));

    this.commonService.getTimetable(+id)
    .subscribe(s => {
      this.schedule = s;
      console.log(this.schedule);
    },
      err => console.log(err));
  }

  generateSchedule() {
    this.commonService.generateTimeTable(this.section.id)
      .subscribe(s => {
        this.schedule = s;
      },
        err => console.log(err));
  }

  saveSchedule(e) {
    this.scheduleService.saveSchedule(this.section.id, this.schedule)
      .subscribe(() => {
        console.log('schedule generated...');
      }, err => console.error(err));
  }
}

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

  constructor(private commonService: CommonService) { }

  ngOnInit() {
  }

}

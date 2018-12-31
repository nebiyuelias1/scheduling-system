import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-section-room-assignment-form',
  templateUrl: './section-room-assignment-form.component.html',
  styleUrls: ['./section-room-assignment-form.component.css']
})
export class SectionRoomAssignmentFormComponent implements OnInit {
  roomTypes: any[];

  constructor(private commonService: CommonService) { }

  ngOnInit() {
    this.commonService.getRoomTypes()
      .subscribe((result: any[]) => this.roomTypes = result,
      (error) => console.error(error));
  }

}

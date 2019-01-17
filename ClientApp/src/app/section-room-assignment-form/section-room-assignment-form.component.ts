import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-section-room-assignment-form',
  templateUrl: './section-room-assignment-form.component.html',
  styleUrls: ['./section-room-assignment-form.component.css']
})
export class SectionRoomAssignmentFormComponent implements OnInit {
  sectionId;
  roomTypes: any[];
  rooms: any[];
  form = new FormGroup({
    typeId: new FormControl(),
    roomId: new FormControl()
  });

  constructor(
    private commonService: CommonService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.sectionId = this.route.snapshot.paramMap.get('id');
    this.commonService.getTypes()
      .subscribe((result: any[]) => this.roomTypes = result,
      (error) => console.error(error));
  }

  onRoomTypeChange(event) {
    this.commonService.getRoomsBasedOnType(event.target.value)
      .subscribe((result: any[]) => this.rooms = result,
      (error) => console.error(error));
  }

  assignRoom() {
    this.commonService.assignSectionToRoom(this.sectionId, this.form.value)
      .subscribe(result => console.log(result),
      error => console.error(error));
  }
}

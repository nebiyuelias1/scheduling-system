import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BuildingService } from '../services/building.service';
import { RoomService } from '../services/room.service';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.css']
})
export class RoomFormComponent implements OnInit {
  buildings: any[];
  roomTypes: any[];
  room = {
    types: []
  };

  constructor(
    private buildingService: BuildingService,
    private roomService: RoomService,
    private commonService: CommonService
    ) { }

  ngOnInit() {
    this.buildingService.get()
      .subscribe((result: any[]) => this.buildings = result,
        (error) => console.error(error));

    this.commonService.getTypes()
      .subscribe((result: any[]) => this.roomTypes = result,
      (error) => console.error(error));
  }

  save() {
    this.roomService.save(this.room)
      .subscribe((result) => console.log(result),
      (error) => console.error(error));
  }

  onRoomTypeChange(event) {
    if (event.target.checked) {
      this.room.types.push(event.target.value);
    } else {
      const index = this.room.types.indexOf(event.target.value);
      this.room.types.splice(index, 1);
    }
  }
}

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BuildingService } from '../services/building.service';
import { RoomService } from '../services/room.service';

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.css']
})
export class RoomFormComponent implements OnInit {
  buildings: any[];
  form = new FormGroup({
    buildingId: new FormControl(),
    name: new FormControl(),
    size: new FormControl(),
    labRoom: new FormControl(),
    lectureRoom: new FormControl(),
    sharedRoom: new FormControl()
  });

  constructor(
    private buildingService: BuildingService,
    private roomService: RoomService
    ) { }

  ngOnInit() {
    this.buildingService.get()
      .subscribe((result: any[]) => this.buildings = result,
        (error) => console.error(error));
  }

  save() {
    this.roomService.save(this.form.value)
      .subscribe((result) => console.log(result),
      error => console.error(error));
  }

}

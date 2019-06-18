import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BuildingService } from '../services/building.service';
import { RoomService } from '../services/room.service';
import { CommonService } from '../services/common.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.css']
})
export class RoomFormComponent implements OnInit {
  buildings: any[];
  roomTypes: any[];
  room: SaveRoom = {
    id: 0,
    name: '',
    buildingId: 0,
    size: 0,
    floor: 0,
    types: []
  };

  constructor(
    private buildingService: BuildingService,
    private roomService: RoomService,
    private commonService: CommonService,
    private route: ActivatedRoute,
    private router: Router
    ) { }

  ngOnInit() {
    const sources = [this.buildingService.getBuildings(),
      this.commonService.getTypes()];

    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      sources.push(this.roomService.getRoom(id));
    }

    Observable.forkJoin(sources)
      .subscribe((x: any) => {
        this.buildings = x[0];
        this.roomTypes = x[1];

        if (id) {
          this.room = x[2];
        }
      }, err => console.error(err));
  }

  submit() {
    const result$ = this.room.id !== 0 ?
      this.roomService.update(this.room) :
      this.roomService.save(this.room);

    result$
      .subscribe(() => this.router.navigate(['/rooms']),
      err => console.error(err));
  }

  onRoomTypeChange(event) {
    if (event.target.checked) {
      this.room.types.push(+event.target.value);
    } else {
      const index = this.room.types.indexOf(+event.target.value);
      this.room.types.splice(index, 1);
    }
  }

  isChecked(typeId) {
    return this.room.types.indexOf(typeId) !== -1;
  }
}

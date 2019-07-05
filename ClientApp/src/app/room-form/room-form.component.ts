import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BuildingService } from '../services/building.service';
import { RoomService } from '../services/room.service';
import { CommonService } from '../services/common.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LabTypeService } from '../services/lab-type.service';

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.css']
})
export class RoomFormComponent implements OnInit {
  buildings: any[];
  roomTypes: any[];
  labTypes: any[];
  room: SaveRoom = {
    id: 0,
    name: '',
    buildingId: 0,
    size: 0,
    floor: 0,
    types: []
  };
  showLabTypeDropdown = false;

  constructor(
    private buildingService: BuildingService,
    private roomService: RoomService,
    private labTypeService: LabTypeService,
    private commonService: CommonService,
    private route: ActivatedRoute,
    private router: Router
    ) { }

  ngOnInit() {
    const sources = [this.buildingService.getBuildings(),
      this.commonService.getTypes(), this.labTypeService.getLabTypes()];

    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      sources.push(this.roomService.getRoom(id));
    }

    Observable.forkJoin(sources)
      .subscribe((x: any) => {
        this.buildings = x[0];
        this.roomTypes = x[1];
        this.labTypes = x[2];

        if (id) {
          this.room = x[3];
          if (this.room.types.some(t => t.typeId === 2)) {
            this.showLabTypeDropdown = true;
          }
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
      if (+event.target.value === 2) {
        this.showLabTypeDropdown = true;
      }
      const type = {
        typeId: +event.target.value,
        labTypeId: null
      };
      this.room.types.push(type);
    } else {
      if (+event.target.value === 2) {
        this.showLabTypeDropdown = false;
      }

      const item = this.room.types.filter(x => x.typeId === +event.target.value)[0];
      const index = this.room.types.indexOf(item);
      this.room.types.splice(index, 1);
    }
  }

  onLabTypeChange(event) {
    const item = this.room.types.filter(x => x.typeId === 2)[0];
    item.labTypeId = event.target.value;
  }

  isChecked(typeId) {
    return this.room.types.some(t => t.typeId === typeId);
  }

  isSelected(labTypeId) {
    return this.room.types.some(t => t.labTypeId === labTypeId);
  }
}

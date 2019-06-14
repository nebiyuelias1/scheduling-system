import { Component, OnInit } from '@angular/core';
import { BuildingService } from '../services/building.service';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-building-form',
  templateUrl: './building-form.component.html',
  styleUrls: ['./building-form.component.css']
})
export class BuildingFormComponent implements OnInit {
  form = new FormGroup({
    name: new FormControl(),
    number: new FormControl(),
    floorCount: new FormControl()
  });

  building: SaveBuilding = {
    id: 0,
    name: '',
    number: 0,
    floorCount: 0
  };

  constructor(
    private buildingService: BuildingService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.buildingService.getBuilding(id)
        .subscribe((result: SaveBuilding) => {
           this.building = result;

           this.populateForm(this.building);
        },
          err => console.error(err));

    }
  }

  submit() {
    const result$ = this.building.id ?
      this.buildingService.updateBuilding(this.building.id, this.form.value) :
      this.buildingService.save(this.form.value);

    result$
      .subscribe(x => this.router.navigate(['/buildings']),
        err => console.error(err));
  }

  populateForm(b: SaveBuilding) {
    this.form.patchValue(b);
  }
}

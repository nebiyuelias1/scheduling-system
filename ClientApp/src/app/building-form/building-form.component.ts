import { Component, OnInit } from '@angular/core';
import { BuildingService } from '../services/building.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-building-form',
  templateUrl: './building-form.component.html',
  styleUrls: ['./building-form.component.css']
})
export class BuildingFormComponent implements OnInit {
  form = new FormGroup({
    name: new FormControl(),
    number: new FormControl()
  });

  constructor(private buildingService: BuildingService) { }

  ngOnInit() {
  }

  save() {
    this.buildingService.save(this.form.value)
      .subscribe((result) => console.log(result),
      (error) => console.error(error));
  }
}

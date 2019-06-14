import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class BuildingService {

  constructor(private http: HttpClient) { }

  save(building) {
    return this.http.post('/api/buildings', building);
  }

  getBuildings() {
    return this.http.get('/api/buildings');
  }
}

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

  getBuilding(id: string) {
    return this.http.get('/api/buildings/' + id);
  }

  updateBuilding(id, building) {
    return this.http.put('/api/buildings/' + id, building);
  }

  delete(id: any) {
    return this.http.delete('/api/buildings/' + id);
  }
}

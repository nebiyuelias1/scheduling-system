import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class LabTypeService {

  constructor(private http: HttpClient) { }

  getLabTypes() {
    return this.http.get('/api/labtypes');
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CommonService {

  constructor(private http: HttpClient) { }

  getProgramTypes() {
    return this.http.get('/api/programs');
  }

  getAdmissionLevels() {
    return this.http.get('/api/admissionlevels');
  }
}

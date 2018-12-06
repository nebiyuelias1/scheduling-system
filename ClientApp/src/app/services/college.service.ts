import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CollegeService {

  constructor(private http: HttpClient) { }

  getColleges() {
    return this.http.get('api/colleges')
  }
}

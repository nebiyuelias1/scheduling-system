import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class CollegeService {

  constructor(private http: HttpClient) { }

  getColleges() {
    return this.http.get('/api/colleges');
  }

  assignDean(id, userId: string) {
    return this.http.put('/api/colleges/' + id, { userId: userId });
  }

  removeAssignment(id: any) {
    return this.http.delete('/api/colleges/' + id);
  }
}

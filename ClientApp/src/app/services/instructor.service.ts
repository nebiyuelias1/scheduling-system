import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class InstructorService {

  constructor(private http: HttpClient) { }

  save(instructor) {
    return this.http.post('/api/instructors', instructor);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class InstructorService {

  constructor(private http: HttpClient) { }

  getInstructor(id) {
    return this.http.get('/api/instructors/' + id);
  }

  save(instructor) {
    return this.http.post('/api/instructors', instructor);
  }

  getInstructors(query) {
    return this.http.get('/api/instructors?' + this.toQueryString(query));
  }

  delete(id: any) {
    return this.http.delete('/api/instructors/' + id);
  }

  toQueryString(obj) {
    const parts = [];
    for (const key of Object.keys(obj)) {
      const value = obj[key];
      if (value !== null && value !== undefined) {
        parts.push(encodeURIComponent(key) + '=' + encodeURIComponent(value));
      }
    }

    return parts.join('&');
  }
}

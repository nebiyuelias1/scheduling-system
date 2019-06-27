import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CourseService {

  constructor(private http: HttpClient) { }

  saveCourse(course) {
    return this.http.post('/api/courses', course);
  }

  getCourses(query) {
    return this.http.get('/api/courses?' + this.toQueryString(query));
  }

  delete(id: any) {
    return this.http.delete('/api/courses/' + id);
  }

  getCourse(id) {
    return this.http.get('/api/courses/' + id);
  }

  update(id, value) {
    return this.http.put('/api/courses/' + id, value);
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

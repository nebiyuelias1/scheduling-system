import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CourseService {

  constructor(private http: HttpClient) { }

  saveCourse(course) {
    return this.http.post('/api/courses', course);
  }

  getCourses() {
    return this.http.get('/api/courses');
  }

  delete(id: any) {
    return this.http.delete('/api/courses/' + id);
  }
}

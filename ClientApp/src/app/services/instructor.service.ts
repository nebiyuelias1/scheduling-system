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

  getInstructors() {
    return this.http.get('/api/instructors');
  }

  delete(id: any) {
    return this.http.delete('/api/instructors/' + id);
  }

  getInstructorsWithinADept(deptId: any) {
    return this.http.get('/api/instructors/' + deptId);
  }
}

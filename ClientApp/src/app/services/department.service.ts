import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DepartmentService {

  constructor(private http: HttpClient) { }

  saveDepartment(department) {
    return this.http.post('/api/departments', department);
  }

  getDepartments() {
    return this.http.get('/api/departments');
  }
}

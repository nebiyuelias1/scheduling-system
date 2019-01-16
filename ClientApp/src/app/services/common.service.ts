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

  getRoomTypes() {
    return this.http.get('/api/roomtypes');
  }

  getRoomsBasedOnType(id: string) {
    return this.http.get('/api/rooms', {
      params: {
        typeId: id
      }
    });
  }

  assignSectionToRoom(id: any, roomAssignmentInfo: any) {
    return this.http.post(`/api/sections/${id}/assign`, roomAssignmentInfo);
  }

  getAcademicYears() {
    return this.http.get('/api/academicyears');
  }

  saveAcademicYear(academicYear) {
    return this.http.post('/api/academicyears', academicYear);
  }

  saveAcademicSemester(academicSemester) {
    return this.http.post('/api/academicsemesters', academicSemester);
  }

  createCourseOfferings() {
    return this.http.get('/api/courseofferings/create');
  }

  getCourseOfferings() {
    return this.http.get('/api/courseofferings');
  }
}

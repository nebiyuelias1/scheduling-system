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

  getTypes() {
    return this.http.get('/api/types');
  }

  getRoomsBasedOnType(id: string) {
    return this.http.get('/api/rooms/' + id);
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

  getInstructors() {
    return this.http.get('/api/instructors');
  }

  assignInstructor(instructorAssignment) {
    return this.http.post('/api/courseofferings', instructorAssignment);
  }

  saveScheduleConfiguration(scheduleConfiguration) {
    return this.http.post('/api/scheduleconfigurations', scheduleConfiguration);
  }

  getCurrentAcademicSemester() {
    return this.http.get('/api/academicsemesters');
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

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

  createCourseOfferings(deptId) {
    return this.http.get('/api/courseofferings/create/' + deptId);
  }

  getCourseOfferings(query) {
    return this.http.get('/api/courseofferings?' + this.toQueryString(query));
  }

  getInstructors() {
    return this.http.get('/api/instructors');
  }

  assignToCourseOffering(instructorAssignment) {
    return this.http.post('/api/courseofferings', instructorAssignment);
  }

  saveScheduleConfiguration(scheduleConfiguration) {
    return this.http.post('/api/scheduleconfigurations', scheduleConfiguration);
  }

  getCurrentAcademicSemester() {
    return this.http.get('/api/academicsemesters');
  }

  getTimetable(sectionId) {
    return this.http.get('/api/schedules/' + sectionId);
  }

  generateTimeTable(sectionId) {
    return this.http.post('/api/schedules/generate/' + sectionId, {});
  }

  getWeekDays() {
    return this.http.get('/api/weekdays');
  }

  getCurriculums() {
    return this.http.get('/api/curriculums');
  }

  getSection(id: number) {
    return this.http.get('/api/sections/' + id);
  }

  deleteCourseOffering(id: any) {
    return this.http.delete('/api/courseofferings/' + id);
  }

  getCourseOffering(courseOfferingId: any) {
    return this.http.get('/api/courseofferings/' + courseOfferingId);
  }

  removeInstructorAssignment(courseOfferingId: any, typeId: any) {
    return this.http.put('/api/courseofferings/' + courseOfferingId, { typeId: typeId });
  }

  removeRoomAssignment(id: any, resource) {
    return this.http.put('/api/courseofferings/' + id, resource);
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

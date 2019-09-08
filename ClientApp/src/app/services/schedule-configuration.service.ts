import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ScheduleConfigurationService {

  constructor(private http: HttpClient) { }

  getScheduleConfiguration(sectionId) {
    return this.http.get('/api/scheduleconfigurations/' + sectionId);
  }
}

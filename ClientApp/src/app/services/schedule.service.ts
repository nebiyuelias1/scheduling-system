import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  constructor(private http: HttpClient) { }

  saveSchedule(id, schedule) {
    return this.http.post('/api/schedules/' + id, schedule);
  }
}

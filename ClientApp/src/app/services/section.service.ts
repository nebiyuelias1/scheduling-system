import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class SectionService {

  constructor(private http: HttpClient) { }

  getSections() {
    return this.http.get('/api/sections');
  }

  save(section) {
    return this.http.post('/api/sections', section);
  }
}

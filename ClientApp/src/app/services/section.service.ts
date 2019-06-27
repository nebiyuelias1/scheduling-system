import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SaveSection } from '../models/save-section-interface';

@Injectable()
export class SectionService {

  constructor(private http: HttpClient) { }

  getSection(id: number) {
    return this.http.get(`/api/sections/${id}`);
  }

  getSections(query) {
    return this.http.get('/api/sections?' + this.toQueryString(query));
  }

  save(section) {
    return this.http.post('/api/sections', section);
  }

  update(id, value: SaveSection) {
    return this.http.put('/api/sections/' + id, value);
  }

  delete(id: any) {
    return this.http.delete('/api/sections/' + id);
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

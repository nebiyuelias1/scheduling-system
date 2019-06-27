import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CurriculumService {

  constructor(private http: HttpClient) { }

  getCurriculums(query) {
    return this.http.get('/api/curriculums?' + this.toQueryString(query));
  }

  save(curriculum) {
    return this.http.post('/api/curriculums', curriculum);
  }

  getCurriculum(id) {
    return this.http.get('/api/curriculums/' + id);
  }

  update(id, value) {
    return this.http.put('/api/curriculums/' + id, value);
  }

  delete(id) {
    return this.http.delete('/api/curriculums/' + id);
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

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SaveSection } from '../models/save-section-interface';

@Injectable()
export class SectionService {

  constructor(private http: HttpClient) { }

  getSection(id: number) {
    return this.http.get(`/api/sections/${id}`);
  }

  getSections() {
    return this.http.get('/api/sections');
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
}

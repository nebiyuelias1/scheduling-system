import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CurriculumService {

  constructor(private http: HttpClient) { }

  getCurriculums()
  {
    return this.http.get('/api/curriculums');
  }

  save(curriculum) {
    return this.http.post('/api/curriculums', curriculum);
  }
}

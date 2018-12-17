import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CurriculumService {

  constructor(private http: HttpClient) { }

  save(curriculum) {
    return this.http.post('/api/curriculums', curriculum);
  }
}

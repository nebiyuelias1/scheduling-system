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

  getCurriculum(id) {
    return this.http.get('/api/curriculums/' + id);
  }

  update(id, value) {
    return this.http.put('/api/curriculums/' + id, value);
  }

  delete(id) {
    return this.http.delete('/api/curriculums/' + id);
  }
  
}

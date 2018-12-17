import { TestBed } from '@angular/core/testing';

import { CurriculumService } from './curriculum.service';

describe('CurriculumService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CurriculumService = TestBed.get(CurriculumService);
    expect(service).toBeTruthy();
  });
});

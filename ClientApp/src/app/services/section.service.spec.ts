import { TestBed } from '@angular/core/testing';

import { SectionService } from './section.service';

describe('SectionService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SectionService = TestBed.get(SectionService);
    expect(service).toBeTruthy();
  });
});

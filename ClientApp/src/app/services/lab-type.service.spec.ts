import { TestBed } from '@angular/core/testing';

import { LabTypeService } from './lab-type.service';

describe('LabTypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LabTypeService = TestBed.get(LabTypeService);
    expect(service).toBeTruthy();
  });
});

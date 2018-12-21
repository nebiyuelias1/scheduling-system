import { TestBed } from '@angular/core/testing';

import { BuildingService } from './building.service';

describe('BuildingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BuildingService = TestBed.get(BuildingService);
    expect(service).toBeTruthy();
  });
});

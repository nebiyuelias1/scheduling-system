import { TestBed } from '@angular/core/testing';

import { ScheduleConfigurationService } from './schedule-configuration.service';

describe('ScheduleConfigurationService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ScheduleConfigurationService = TestBed.get(ScheduleConfigurationService);
    expect(service).toBeTruthy();
  });
});

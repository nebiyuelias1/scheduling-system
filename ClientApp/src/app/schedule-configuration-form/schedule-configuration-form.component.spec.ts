import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleConfigurationFormComponent } from './schedule-configuration-form.component';

describe('ScheduleConfigurationFormComponent', () => {
  let component: ScheduleConfigurationFormComponent;
  let fixture: ComponentFixture<ScheduleConfigurationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScheduleConfigurationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScheduleConfigurationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

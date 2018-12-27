import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionRoomAssignmentFormComponent } from './section-room-assignment-form.component';

describe('SectionRoomAssignmentFormComponent', () => {
  let component: SectionRoomAssignmentFormComponent;
  let fixture: ComponentFixture<SectionRoomAssignmentFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SectionRoomAssignmentFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionRoomAssignmentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

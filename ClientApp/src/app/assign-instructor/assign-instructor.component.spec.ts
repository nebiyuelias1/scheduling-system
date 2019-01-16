import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignInstructorComponent } from './assign-instructor.component';

describe('AssignInstructorComponent', () => {
  let component: AssignInstructorComponent;
  let fixture: ComponentFixture<AssignInstructorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssignInstructorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignInstructorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

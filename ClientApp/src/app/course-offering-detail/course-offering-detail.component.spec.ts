import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseOfferingDetailComponent } from './course-offering-detail.component';

describe('AssignInstructorComponent', () => {
  let component: CourseOfferingDetailComponent;
  let fixture: ComponentFixture<CourseOfferingDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CourseOfferingDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseOfferingDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

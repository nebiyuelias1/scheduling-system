import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseOfferingsListComponent } from './course-offerings-list.component';

describe('CourseOfferingsListComponent', () => {
  let component: CourseOfferingsListComponent;
  let fixture: ComponentFixture<CourseOfferingsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CourseOfferingsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseOfferingsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcademicYearFormComponent } from './academic-year-form.component';

describe('AcademicYearFormComponent', () => {
  let component: AcademicYearFormComponent;
  let fixture: ComponentFixture<AcademicYearFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcademicYearFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcademicYearFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

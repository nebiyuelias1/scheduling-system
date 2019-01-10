import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcademicSemesterFormComponent } from './academic-semester-form.component';

describe('AcademicSemesterFormComponent', () => {
  let component: AcademicSemesterFormComponent;
  let fixture: ComponentFixture<AcademicSemesterFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcademicSemesterFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcademicSemesterFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

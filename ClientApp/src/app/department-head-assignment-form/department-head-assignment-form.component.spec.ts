import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentHeadAssignmentFormComponent } from './department-head-assignment-form.component';

describe('DepartmentHeadAssignmentFormComponent', () => {
  let component: DepartmentHeadAssignmentFormComponent;
  let fixture: ComponentFixture<DepartmentHeadAssignmentFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepartmentHeadAssignmentFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartmentHeadAssignmentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

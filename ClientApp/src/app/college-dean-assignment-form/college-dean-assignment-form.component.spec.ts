import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CollegeDeanAssignmentFormComponent } from './college-dean-assignment-form.component';

describe('CollegeDeanAssignmentFormComponent', () => {
  let component: CollegeDeanAssignmentFormComponent;
  let fixture: ComponentFixture<CollegeDeanAssignmentFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CollegeDeanAssignmentFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CollegeDeanAssignmentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurriculumFormComponent } from './curriculum-form.component';

describe('CurriculumFormComponent', () => {
  let component: CurriculumFormComponent;
  let fixture: ComponentFixture<CurriculumFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurriculumFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurriculumFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

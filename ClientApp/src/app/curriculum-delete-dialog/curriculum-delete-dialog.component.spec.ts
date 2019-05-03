import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurriculumDeleteDialogComponent } from './curriculum-delete-dialog.component';

describe('CurriculumDeleteDialogComponent', () => {
  let component: CurriculumDeleteDialogComponent;
  let fixture: ComponentFixture<CurriculumDeleteDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurriculumDeleteDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurriculumDeleteDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

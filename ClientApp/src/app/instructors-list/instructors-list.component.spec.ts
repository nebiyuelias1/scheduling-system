import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorsListComponent } from './instructors-list.component';

describe('InstructorsListComponent', () => {
  let component: InstructorsListComponent;
  let fixture: ComponentFixture<InstructorsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstructorsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstructorsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisrationFormComponent } from './regisration-form.component';

describe('RegisrationFormComponent', () => {
  let component: RegisrationFormComponent;
  let fixture: ComponentFixture<RegisrationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisrationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisrationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionDetailComponent } from './section-detail.component';

describe('SectionDetailComponent', () => {
  let component: SectionDetailComponent;
  let fixture: ComponentFixture<SectionDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SectionDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

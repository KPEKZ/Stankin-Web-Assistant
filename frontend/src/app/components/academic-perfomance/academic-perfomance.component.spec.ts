import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcademicPerfomanceComponent } from './academic-perfomance.component';

describe('AcademicPerfomanceComponent', () => {
  let component: AcademicPerfomanceComponent;
  let fixture: ComponentFixture<AcademicPerfomanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcademicPerfomanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AcademicPerfomanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

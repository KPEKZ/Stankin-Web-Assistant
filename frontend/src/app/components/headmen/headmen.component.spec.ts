import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeadmenComponent } from './headmen.component';

describe('HeadmenComponent', () => {
  let component: HeadmenComponent;
  let fixture: ComponentFixture<HeadmenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeadmenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeadmenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservationdetailsComponent } from './reservationdetails.component';

describe('ReservationdetailsComponent', () => {
  let component: ReservationdetailsComponent;
  let fixture: ComponentFixture<ReservationdetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ReservationdetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservationdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

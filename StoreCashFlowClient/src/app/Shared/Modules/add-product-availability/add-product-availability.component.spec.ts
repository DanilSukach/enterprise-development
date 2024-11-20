import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProductAvailabilityComponent } from './add-product-availability.component';

describe('AddProductAvailabilityComponent', () => {
  let component: AddProductAvailabilityComponent;
  let fixture: ComponentFixture<AddProductAvailabilityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddProductAvailabilityComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddProductAvailabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

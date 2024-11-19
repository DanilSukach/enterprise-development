import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductAvailabilityListComponent } from './product-availability-list.component';

describe('ProductAvailabilityListComponent', () => {
  let component: ProductAvailabilityListComponent;
  let fixture: ComponentFixture<ProductAvailabilityListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductAvailabilityListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductAvailabilityListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

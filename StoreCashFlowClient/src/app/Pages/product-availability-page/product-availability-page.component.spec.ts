import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductAvailabilityPageComponent } from './product-availability-page.component';

describe('ProductAvailabilityPageComponent', () => {
  let component: ProductAvailabilityPageComponent;
  let fixture: ComponentFixture<ProductAvailabilityPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductAvailabilityPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductAvailabilityPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

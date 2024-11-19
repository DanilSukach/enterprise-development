import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllProductsInStoreComponent } from './all-products-in-store.component';

describe('AllProductsInStoreComponent', () => {
  let component: AllProductsInStoreComponent;
  let fixture: ComponentFixture<AllProductsInStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AllProductsInStoreComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllProductsInStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

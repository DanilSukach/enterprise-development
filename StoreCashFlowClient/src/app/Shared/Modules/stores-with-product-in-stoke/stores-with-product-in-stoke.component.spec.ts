import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoresWithProductInStokeComponent } from './stores-with-product-in-stoke.component';

describe('StoresWithProductInStokeComponent', () => {
  let component: StoresWithProductInStokeComponent;
  let fixture: ComponentFixture<StoresWithProductInStokeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StoresWithProductInStokeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoresWithProductInStokeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoresWithHighSalesComponent } from './stores-with-high-sales.component';

describe('StoresWithHighSalesComponent', () => {
  let component: StoresWithHighSalesComponent;
  let fixture: ComponentFixture<StoresWithHighSalesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StoresWithHighSalesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoresWithHighSalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

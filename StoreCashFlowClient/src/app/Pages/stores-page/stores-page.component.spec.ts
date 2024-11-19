import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoresPageComponent } from './stores-page.component';

describe('StoresPageComponent', () => {
  let component: StoresPageComponent;
  let fixture: ComponentFixture<StoresPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StoresPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoresPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

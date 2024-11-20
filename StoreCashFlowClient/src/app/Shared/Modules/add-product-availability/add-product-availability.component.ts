import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {Product, ProductAvailabilityService, ProductService, Store, StoreService} from "../../../api";
import {NgClass, NgForOf, NgIf} from "@angular/common";
import {combineLatest} from "rxjs";

@Component({
  selector: 'app-add-product-availability',
  standalone: true,
  imports: [
    FormsModule,
    NgForOf,
    NgIf,
    ReactiveFormsModule,
    NgClass
  ],
  templateUrl: './add-product-availability.component.html',
  styleUrl: './add-product-availability.component.css'
})
export class AddProductAvailabilityComponent implements OnInit {
  isFormOpen = false;
  productAvailabilityForm: FormGroup;
  products: Product[] = [];
  stores: Store[] = [];
  @Output() productAvailabilityAdded = new EventEmitter<void>();

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private storeService: StoreService,
    private productAvailabilityService: ProductAvailabilityService
  ) {
    this.productAvailabilityForm = this.fb.group({
      storeId: [1, Validators.required],
      productId: [1, Validators.required],
      quantity: [0, [Validators.required, this.numberValidator]],
    });
  }

  ngOnInit(): void {
    combineLatest([
      this.productService.apiProductGet(),
      this.storeService.apiStoreGet()
    ]).subscribe(([products, stores]) => {
      this.products = products;
      this.stores = stores;

      if (this.products.length > 0) {
        this.productAvailabilityForm.patchValue({
          productId: this.products[0].barcode
        });
      }

      if (this.stores.length > 0) {
        this.productAvailabilityForm.patchValue({
          storeId: this.stores[0].storeId
        });
      }
    });
  }

  numberValidator(control: AbstractControl) {
    const value = control.value;
    if (value && isNaN(value)) {
      return {invalidNumber: true};
    }
    return null;
  }

  openForm(): void {
    this.isFormOpen = true;
  }

  closeForm(): void {
    this.isFormOpen = false;
    this.productAvailabilityForm.reset({storeId: this.stores[0].storeId, productId: this.products[0].barcode});
  }

  onSubmit(): void {
    if (this.productAvailabilityForm.valid) {
      const newProduct = this.productAvailabilityForm.value;
      newProduct.quantity = Number(this.productAvailabilityForm.value.quantity);
      this.productAvailabilityService.apiProductAvailabilityPost(newProduct).subscribe({
        next: () => {
          this.productAvailabilityAdded.emit();
          this.closeForm();
        }
      });
    }
  }

  get quantityControl() {
    return this.productAvailabilityForm.get('quantity');
  }
}

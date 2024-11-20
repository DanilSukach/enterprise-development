import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {Customer, CustomerService, Product, ProductService, SaleService, Store, StoreService} from "../../../api";
import {combineLatest} from "rxjs";
import {NgClass, NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-add-sale',
  standalone: true,
  imports: [
    FormsModule,
    NgForOf,
    NgIf,
    ReactiveFormsModule,
    NgClass
  ],
  templateUrl: './add-sale.component.html',
  styleUrl: './add-sale.component.css'
})
export class AddSaleComponent implements OnInit {
  isFormOpen = false;
  saleForm: FormGroup;
  products: Product[] = [];
  stores: Store[] = [];
  customers: Customer[] = [];
  @Output() saleAdded = new EventEmitter<void>();

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private storeService: StoreService,
    private customerService: CustomerService,
    private saleService: SaleService
  ) {
    this.saleForm = this.fb.group({
      storeId: [1, Validators.required],
      productId: [1, Validators.required],
      quantity: [0, [Validators.required, this.numberValidator]],
      saleDate: ['', Validators.required],
      customerId: [1, Validators.required]
    });
  }

  ngOnInit(): void {
    combineLatest([
      this.productService.apiProductGet(),
      this.storeService.apiStoreGet(),
      this.customerService.apiCustomerGet()
    ]).subscribe(([products, stores, customers]) => {
      this.products = products;
      this.stores = stores;
      this.customers = customers;

      if (this.products.length > 0) {
        this.saleForm.patchValue({
          productId: this.products[0].barcode
        });
      }

      if (this.stores.length > 0) {
        this.saleForm.patchValue({
          storeId: this.stores[0].storeId
        });
      }

      if (this.customers.length > 0) {
        this.saleForm.patchValue({
          customerId: this.customers[0].customerId
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
    this.saleForm.reset({storeId: this.stores[0].storeId, productId: this.products[0].barcode});
  }

  onSubmit(): void {
    if (this.saleForm.valid) {
      const newSale = this.saleForm.value;
      newSale.quantity = Number(this.saleForm.value.quantity);
      newSale.saleDate = new Date(this.saleForm.value.saleDate).toISOString();
      this.saleService.apiSalePost(newSale).subscribe({
        next: () => {
          this.saleAdded.emit();
          this.closeForm();
        }
      });
    }
  }

  get quantityControl() {
    return this.saleForm.get('quantity');
  }
}

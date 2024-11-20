import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {NgClass, NgForOf, NgIf} from "@angular/common";
import {AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {ProductService, ProductType, ProductTypeService} from "../../../api";

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule,
    NgForOf,
    NgClass
  ],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent implements OnInit {
  isFormOpen = false;
  productForm: FormGroup;
  productTypes: ProductType[] = [];
  @Output() productAdded = new EventEmitter<void>();

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private productTypeService: ProductTypeService
  ) {
    this.productForm = this.fb.group({
      barcode: ['', Validators.required],
      productGroupCode: ['', Validators.required],
      name: ['', Validators.required],
      weight: [0, [Validators.required, this.numberValidator]],
      productTypeId: [1],
      price: [0, [Validators.required, this.numberValidator]],
      expirationDate: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.productTypeService.apiProductTypeGet().subscribe(productTypes => {
      this.productTypes = productTypes;
      if (this.productTypes.length > 0) {
        this.productForm.value.productTypeId = this.productTypes[0].id;
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
    this.productForm.reset({productTypeId: this.productTypes[0].id});
  }

  onSubmit(): void {
    if (this.productForm.valid) {
      const newProduct = this.productForm.value;
      newProduct.weight = Number(this.productForm.value.weight);
      newProduct.price = Number(this.productForm.value.price);
      newProduct.expirationDate = new Date(this.productForm.value.expirationDate).toISOString();
      this.productService.apiProductPost(newProduct).subscribe({
        next: () => {
          this.productAdded.emit();
          this.closeForm();
        }
      });
    }
  }

  get weightControl() {
    return this.productForm.get('weight');
  }

  get priceControl() {
    return this.productForm.get('price');
  }
}

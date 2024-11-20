import {Component, OnInit} from '@angular/core';
import {
  Product,
  ProductAvailability,
  ProductAvailabilityDTO,
  ProductAvailabilityService,
  ProductService,
  Store,
  StoreService
} from '../../../api';
import {NgForOf, NgIf} from '@angular/common';
import {ActionButtonsComponent} from "../../Components/action-buttons/action-buttons.component";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-product-availability-list',
  standalone: true,
  imports: [
    NgForOf,
    ActionButtonsComponent,
    FormsModule,
    NgIf
  ],
  templateUrl: './product-availability-list.component.html',
  styleUrl: './product-availability-list.component.css'
})
export class ProductAvailabilityListComponent implements OnInit {
  productsAvailabilities: ProductAvailability[] = [];
  products: Product[] = [];
  stores: Store[] = [];
  editingStates: { [id: number]: boolean } = {};
  originalProducts: { [id: number]: ProductAvailability } = {};

  constructor(private productAvailabilityService: ProductAvailabilityService, private productService: ProductService, private storeService: StoreService) {
  }

  ngOnInit(): void {
    this.loadProductAvailability();
  }

  startEdit(productId: number): void {
    this.editingStates[productId] = true;
  }

  saveProduct(product: ProductAvailability): void {
    const oldProduct = this.originalProducts[product.id!];
    console.log(oldProduct)
    if (!oldProduct) {
      this.editingStates[product.id!] = false;
      return;
    }

    const newQuantity = Number(product.quantity);
    if (isNaN(newQuantity)) {
      product.quantity = oldProduct.quantity;
    }

    const productDTO: ProductAvailabilityDTO = {
      id: product.id,
      storeId: product.store.storeId,
      productId: product.product.barcode,
      quantity: product.quantity
    };
    console.log(productDTO);
    this.productAvailabilityService.apiProductAvailabilityPut(productDTO).subscribe(() => {
      this.loadProductAvailability();
    });
  }

  cancelEdit(productId: number): void {
    const original = this.originalProducts[productId!];
    if (original) {
      const index = this.productsAvailabilities.findIndex(c => c.id === productId);
      if (index !== -1) {
        Object.assign(this.productsAvailabilities[index], original);
      }
    }
    this.editingStates[productId] = false;
  }

  deleteProduct(productId: number): void {
    this.productAvailabilityService.apiProductAvailabilityDelete(productId).subscribe({
      next: () => {
        this.productAvailabilityService.apiProductAvailabilityGet().subscribe(products => {
          this.productsAvailabilities = products;
        });
      }
    });
  }

  loadProductAvailability(): void {
    this.productAvailabilityService.apiProductAvailabilityGet().subscribe((products) => {
      this.productsAvailabilities = products
      this.productsAvailabilities.forEach((product) => {
        this.editingStates[product.id!] = false;
        this.originalProducts[product.id!] = {...product};
      });
    });
    this.productService.apiProductGet().subscribe((products) =>
      this.products = products
    );
    this.storeService.apiStoreGet().subscribe((stores) =>
      this.stores = stores
    );
  }
}

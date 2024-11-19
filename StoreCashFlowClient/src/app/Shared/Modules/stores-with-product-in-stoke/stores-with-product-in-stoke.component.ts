import {Component, OnInit} from '@angular/core';
import {Product, ProductService, RequestService, Store} from "../../../api";
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";

@Component({
  selector: 'app-stores-with-product-in-stoke',
  standalone: true,
  imports: [
    NgForOf,
    NgIf,
    ReactiveFormsModule,
    FormsModule
  ],
  templateUrl: './stores-with-product-in-stoke.component.html',
  styleUrl: './stores-with-product-in-stoke.component.css'
})
export class StoresWithProductInStokeComponent implements OnInit {
  stores: Store[] = [];
  selectedProductId!: string;
  products: Product[] = [];

  constructor(private productService: ProductService, private request: RequestService) {
  }

  ngOnInit(): void {
    this.loadStores();
  }

  loadStores(): void {
    this.productService.apiProductGet().subscribe((products) => {
      this.products = products;
    });
  }

  fetchStoresForProduct(): void {
    if (!this.selectedProductId) {
      return;
    }
    this.request.apiRequestReturnStoresWithProductInStokeGet(this.selectedProductId).subscribe((stores) => {
      this.stores = stores;
    });
  }
}

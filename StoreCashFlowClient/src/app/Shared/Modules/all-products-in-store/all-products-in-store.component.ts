import {Component, OnInit} from '@angular/core';
import {Product, RequestService, Store, StoreService} from '../../../api';
import {FormsModule} from '@angular/forms';
import {NgForOf, NgIf, NgStyle} from '@angular/common';

@Component({
  selector: 'app-all-products-in-store',
  standalone: true,
  imports: [
    FormsModule,
    NgIf,
    NgForOf,
    NgStyle
  ],
  templateUrl: './all-products-in-store.component.html',
  styleUrl: './all-products-in-store.component.css'
})
export class AllProductsInStoreComponent implements OnInit {
  stores: Store[] = [];
  selectedStoreId!: number;
  products: Product[] = [];

  constructor(private storeService: StoreService, private request: RequestService) {
  }

  ngOnInit(): void {
    this.loadStores();
  }

  loadStores(): void {
    this.storeService.apiStoreGet().subscribe((stores) => {
      this.stores = stores;
    });
  }

  fetchProductsForStore(): void {
    if (!this.selectedStoreId) {
      return;
    }
    this.request.apiRequestReturnAllProductsInStoreGet(this.selectedStoreId).subscribe((products) => {
      this.products = products;
    });
  }
}

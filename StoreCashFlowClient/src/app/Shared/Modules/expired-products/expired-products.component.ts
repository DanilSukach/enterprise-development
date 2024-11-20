import {Component, OnInit} from '@angular/core';
import {ExpiredProductInfoDto, RequestService, Store, StoreService} from "../../../api";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-expired-products',
  standalone: true,
  imports: [
    FormsModule,
    NgForOf,
    NgIf,
    ReactiveFormsModule
  ],
  templateUrl: './expired-products.component.html',
  styleUrl: './expired-products.component.css'
})
export class ExpiredProductsComponent implements OnInit {
  stores: Store[] = [];
  date!: string;
  products: ExpiredProductInfoDto[] = [];

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

  fetchProducts(): void {
    if (!this.date) {
      return;
    }
    const newDate = new Date(this.date).toISOString();
    this.request.apiRequestReturnExpiredProductsGet(newDate).subscribe((products) => {
      this.products = products;
    });
  }
}

import {Component} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {HighSalesDto, RequestService, Store, StoreService} from "../../../api";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-stores-with-high-sales',
  standalone: true,
  imports: [
    NgForOf,
    NgIf,
    FormsModule
  ],
  templateUrl: './stores-with-high-sales.component.html',
  styleUrl: './stores-with-high-sales.component.css'
})
export class StoresWithHighSalesComponent {
  stores: HighSalesDto[] = [];
  data1!: string;
  data2!: string;
  money!: number;
  storeRequest: Store[] = [];

  constructor(private request: RequestService, private storeService: StoreService) {
  }

  fetchStores(): void {
    if (!this.money) {
      return;
    }
    const newData1 = new Date(this.data1).toISOString();
    const newData2 = new Date(this.data2).toISOString();
    this.request.apiRequestGetStoresWithHighSalesGet(newData1, newData2, this.money).subscribe((stores) => {
      this.stores = stores;
      this.stores.forEach((store) => {
        this.storeRequest = [];
        this.storeService.apiStoreIdGet(store.storeId!).subscribe((store) => {
          this.storeRequest.push(store);
        });
      });
    });
  }
}

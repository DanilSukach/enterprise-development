import {Component, OnInit} from '@angular/core';
import {ActionButtonsComponent} from "../../Components/action-buttons/action-buttons.component";
import {NgForOf} from "@angular/common";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {Store, StoreService} from '../../../api';

@Component({
  selector: 'app-store-list',
  standalone: true,
  imports: [
    ActionButtonsComponent,
    NgForOf,
    ReactiveFormsModule,
    FormsModule
  ],
  templateUrl: './store-list.component.html',
  styleUrl: './store-list.component.css'
})
export class StoreListComponent implements OnInit {
  stores: Store[] = [];
  editingStates: { [id: number]: boolean } = {};
  originalStores: { [id: number]: Store } = {};

  constructor(private storeService: StoreService) {
  }

  ngOnInit(): void {
    this.loadStores();
  }

  startEdit(storeId: number): void {
    this.editingStates[storeId] = true;
  }

  saveStore(store: Store): void {
    this.storeService.apiStorePut(store).subscribe(() => {
      this.editingStates[store.storeId!] = false;
      this.originalStores[store.storeId!] = {...store};
    });
  }

  cancelEdit(storeId: number): void {
    const original = this.originalStores[storeId];
    if (original) {
      const index = this.stores.findIndex(c => c.storeId === storeId);
      if (index !== -1) {
        Object.assign(this.stores[index], original);
      }
    }
    this.editingStates[storeId] = false;
  }

  deleteCustomer(customerId: number): void {
    this.storeService.apiStoreIdDelete(customerId).subscribe({
      next: () => {
        this.storeService.apiStoreGet().subscribe(stores => {
          this.stores = stores;
        });
      }
    });
  }

  loadStores(): void {
    this.storeService.apiStoreGet().subscribe((stores) => {
      this.stores = stores;
      this.stores.forEach((store) => {
        this.editingStates[store.storeId!] = false;
        this.originalStores[store.storeId!] = {...store};
      });
    });
  }
}

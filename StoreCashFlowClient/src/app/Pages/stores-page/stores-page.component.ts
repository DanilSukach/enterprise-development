import {Component, ViewChild} from '@angular/core';
import {AddStoreComponent} from '../../Shared/Modules/add-store/add-store.component';
import {StoreListComponent} from '../../Shared/Modules/store-list/store-list.component';
import {CustomerListComponent} from '../../Shared/Modules/customer-list/customer-list.component';

@Component({
  selector: 'app-stores-page',
  standalone: true,
  imports: [AddStoreComponent, StoreListComponent],
  templateUrl: './stores-page.component.html',
  styleUrl: './stores-page.component.css'
})
export class StoresPageComponent {
  currentTitle: string = 'Магазины';

  @ViewChild(StoreListComponent) storeListComponent!: StoreListComponent;

  onStoreAdded() {
    this.storeListComponent.loadStores();
  }
}

import {Component, ViewChild} from '@angular/core';
import {CustomerListComponent} from '../../Shared/Modules/customer-list/customer-list.component';
import {AddCustomerComponent} from '../../Shared/Modules/add-customer/add-customer.component';


@Component({
  selector: 'app-customer-list-page',
  standalone: true,
  imports: [
    CustomerListComponent,
    AddCustomerComponent
  ],
  templateUrl: './customers-page.component.html',
  styleUrl: './customers-page.component.css'
})
export class CustomersPageComponent {
  currentTitle: string = 'Покупатели';
  @ViewChild(CustomerListComponent) customerListComponent!: CustomerListComponent;

  onCustomerAdded() {
    this.customerListComponent.loadCustomers();
  }
}

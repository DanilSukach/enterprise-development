import {Component, OnInit} from '@angular/core';

import {NgForOf} from '@angular/common';
import {ActionButtonsComponent} from '../../Components/action-buttons/action-buttons.component';
import {FormsModule} from '@angular/forms';
import {Customer, CustomerService} from '../../../api';


@Component({
  selector: 'app-customer-list',
  standalone: true,
  imports: [
    NgForOf,
    ActionButtonsComponent,
    FormsModule
  ],
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css'
})
export class CustomerListComponent implements OnInit {
  customers: Customer[] = [];
  editingStates: { [id: number]: boolean } = {};
  originalCustomers: { [id: number]: Customer } = {};

  constructor(private customerService: CustomerService) {
  }

  ngOnInit(): void {
    this.loadCustomers();
  }

  startEdit(customerId: number): void {
    this.editingStates[customerId] = true;
  }

  saveCustomer(customer: Customer): void {
    this.customerService.apiCustomerPut(customer).subscribe(() => {
      this.editingStates[customer.customerId!] = false;
      this.originalCustomers[customer.customerId!] = {...customer};
    });
  }

  cancelEdit(customerId: number): void {
    const original = this.originalCustomers[customerId];
    if (original) {
      const index = this.customers.findIndex(c => c.customerId === customerId);
      if (index !== -1) {
        Object.assign(this.customers[index], original);
      }
    }
    this.editingStates[customerId] = false;
  }

  deleteCustomer(customerId: number): void {
    this.customerService.apiCustomerIdDelete(customerId).subscribe({
      next: () => {
        this.customerService.apiCustomerGet().subscribe(customers => {
          this.customers = customers;
        });
      }
    });
  }

  loadCustomers(): void {
    this.customerService.apiCustomerGet().subscribe((customers) => {
      this.customers = customers;
      this.customers.forEach((customer) => {
        this.editingStates[customer.customerId] = false;
        this.originalCustomers[customer.customerId] = {...customer};
      });
    });
  }
}

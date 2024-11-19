import {Component, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {NgIf} from '@angular/common';
import {CustomerService} from '../../../api';

@Component({
  selector: 'app-add-customer',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    NgIf
  ],
  templateUrl: './add-customer.component.html',
  styleUrl: './add-customer.component.css'
})
export class AddCustomerComponent {
  isFormOpen = false;
  customerForm: FormGroup;
  @Output() customerAdded = new EventEmitter<void>();

  constructor(private fb: FormBuilder, private customerService: CustomerService) {
    this.customerForm = this.fb.group({
      cardNumber: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      patronymic: [' ']
    });
  }

  openForm(): void {
    this.isFormOpen = true;
  }

  closeForm(): void {
    this.isFormOpen = false;
    this.customerForm.reset({patronymic: ''});
  }

  onSubmit(): void {
    if (this.customerForm.valid) {
      const newCustomer = this.customerForm.value;
      this.customerService.apiCustomerPost(newCustomer).subscribe({
        next: () => {
          this.customerForm.reset({patronymic: ' '});
          this.customerAdded.emit();
          this.closeForm();
        }
      });
    }
  }
}

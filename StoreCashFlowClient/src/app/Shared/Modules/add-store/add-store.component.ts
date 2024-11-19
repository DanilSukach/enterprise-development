import {Component, EventEmitter, Output} from '@angular/core';
import {NgIf} from "@angular/common";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {StoreService} from '../../../api';

@Component({
  selector: 'app-add-store',
  standalone: true,
    imports: [
        NgIf,
        ReactiveFormsModule
    ],
  templateUrl: './add-store.component.html',
  styleUrl: './add-store.component.css'
})
export class AddStoreComponent {
  isFormOpen = false;
  storeForm: FormGroup;
  @Output() storeAdded = new EventEmitter<void>();

  constructor(private fb: FormBuilder, private storeService: StoreService) {
    this.storeForm = this.fb.group({
      location: ['', Validators.required]
    });
  }

  openForm(): void {
    this.isFormOpen = true;
  }

  closeForm(): void {
    this.isFormOpen = false;
    this.storeForm.reset();
  }

  onSubmit(): void {
    if (this.storeForm.valid) {
      const newCustomer = this.storeForm.value;
      this.storeService.apiStorePost(newCustomer).subscribe({
        next: () => {
          this.storeAdded.emit();
          this.closeForm();
        }
      });
    }
  }
}

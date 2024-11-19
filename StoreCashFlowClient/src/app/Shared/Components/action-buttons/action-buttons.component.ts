import {Component, EventEmitter, Input, Output} from '@angular/core';
import {NgIf} from '@angular/common';

@Component({
  selector: 'app-action-buttons',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './action-buttons.component.html',
  styleUrl: './action-buttons.component.css'
})
export class ActionButtonsComponent<T> {
  @Input() itemId!: T;
  @Output() delete = new EventEmitter<T>();
  @Output() save = new EventEmitter<void>();
  @Output() edit = new EventEmitter<T>();
  @Output() cancel = new EventEmitter<T>();

  isEditing = false;

  startEdit() {
    this.isEditing = true;
    this.edit.emit(this.itemId);
  }

  saveEdit() {
    this.isEditing = false;
    this.save.emit();
  }

  cancelEdit() {
    this.isEditing = false;
    this.cancel.emit(this.itemId);
  }
}

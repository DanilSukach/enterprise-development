import {Component, OnInit} from '@angular/core';
import {Product, ProductService} from '../../../api';
import {ActionButtonsComponent} from '../../Components/action-buttons/action-buttons.component';
import {NgForOf} from '@angular/common';
import {ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [
    ActionButtonsComponent,
    NgForOf,
    ReactiveFormsModule
  ],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];

  constructor(private productService: ProductService) {
  }

  ngOnInit(): void {
    this.loadProducts();
  }

  deleteSale(productId: string): void {
    this.productService.apiProductIdDelete(productId).subscribe({
      next: () => {
        this.productService.apiProductGet().subscribe(products => {
          this.products = products;
        });
      }
    });
  }

  loadProducts(): void {
    this.productService.apiProductGet().subscribe((products) =>
      this.products = products
    );
  }
}

import {Component, OnInit} from '@angular/core';
import {ProductAvailability, ProductAvailabilityService} from '../../../api';
import {NgForOf} from '@angular/common';

@Component({
  selector: 'app-product-availability-list',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './product-availability-list.component.html',
  styleUrl: './product-availability-list.component.css'
})
export class ProductAvailabilityListComponent implements OnInit {
  productsAvailability: ProductAvailability[] = [];

  constructor(private productAvailabilityService: ProductAvailabilityService ) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  deleteCustomer(productId: number): void {
    this.productAvailabilityService.apiProductAvailabilityDelete(productId).subscribe({
      next: () => {
        this.productAvailabilityService.apiProductAvailabilityGet().subscribe(products => {
          this.productsAvailability = products;
        });
      }
    });
  }

  loadProducts(): void {
    this.productAvailabilityService.apiProductAvailabilityGet().subscribe((products) =>
      this.productsAvailability = products
    );
  }
}

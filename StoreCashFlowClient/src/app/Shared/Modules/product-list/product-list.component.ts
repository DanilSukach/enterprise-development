import {Component, OnInit} from '@angular/core';
import {Product, ProductDTO, ProductService, ProductType, ProductTypeService} from '../../../api';
import {ActionButtonsComponent} from '../../Components/action-buttons/action-buttons.component';
import {DatePipe, NgForOf, NgIf} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [
    ActionButtonsComponent,
    NgForOf,
    ReactiveFormsModule,
    FormsModule,
    NgIf,
    DatePipe
  ],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  editingStates: { [id: string]: boolean } = {};
  originalProducts: { [id: string]: Product } = {};
  productTypes: ProductType[] = [];

  constructor(private productService: ProductService, private productTypeService: ProductTypeService) {
  }

  ngOnInit(): void {
    this.loadProducts();
  }

  startEdit(storeId: string): void {
    this.editingStates[storeId] = true;
  }

  saveStore(product: Product): void {
    const oldProduct = this.originalProducts[product.barcode];

    if (!oldProduct) {
      this.editingStates[product.barcode] = false;
      return;
    }

    const newWeight = Number(product.weight);
    if (isNaN(newWeight)) {
      product.weight = oldProduct.weight;
    }

    const newPrice = Number(product.price);
    if (isNaN(newPrice)) {
      product.price = oldProduct.price;
    }
    product.expirationDate = new Date(product.expirationDate).toISOString();
    const productDTO: ProductDTO = {
      barcode: product.barcode,
      productGroupCode: product.productGroupCode,
      name: product.name,
      weight: product.weight,
      price: product.price,
      productTypeId: product.productType.id,
      expirationDate: product.expirationDate
    };

    this.productService.apiProductPut(productDTO).subscribe(() => {
      this.loadProducts();
    });
  }

  cancelEdit(productId: string): void {
    const original = this.originalProducts[productId];
    if (original) {
      const index = this.products.findIndex(c => c.barcode === productId);
      if (index !== -1) {
        Object.assign(this.products[index], original);
      }
    }
    this.editingStates[productId] = false;
  }

  deleteCustomer(productId: string): void {
    this.productService.apiProductIdDelete(productId).subscribe({
      next: () => {
        this.productService.apiProductGet().subscribe(products => {
          this.products = products;
        });
      }
    });
  }

  loadProducts(): void {
    this.productService.apiProductGet().subscribe((products) => {
      this.products = products.map(product => ({
        ...product,
        expirationDate: product.expirationDate.substring(0, 16)
      }));
      this.products.forEach((product) => {
        this.editingStates[product.barcode] = false;
        this.originalProducts[product.barcode] = {...product};
      });
    });
    this.productTypeService.apiProductTypeGet().subscribe(productTypes => {
      this.productTypes = productTypes;
    });
  }
}

import {Component, OnInit} from '@angular/core';
import {
  Customer,
  CustomerService,
  Product,
  ProductService,
  Sale,
  SaleDTO,
  SaleService,
  Store,
  StoreService
} from '../../../api';
import {ActionButtonsComponent} from '../../Components/action-buttons/action-buttons.component';
import {NgForOf, NgIf} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-sale-list',
  standalone: true,
  imports: [
    ActionButtonsComponent,
    NgForOf,
    ReactiveFormsModule,
    NgIf,
    FormsModule
  ],
  templateUrl: './sale-list.component.html',
  styleUrl: './sale-list.component.css'
})
export class SaleListComponent implements OnInit {
  sales: Sale[] = [];
  editingStates: { [id: number]: boolean } = {};
  originalSales: { [id: number]: Sale } = {};
  products: Product[] = [];
  stores: Store[] = [];
  customers: Customer[] = [];

  constructor(private saleService: SaleService,
              private productService: ProductService,
              private storeService: StoreService,
              private customerService: CustomerService) {
  }

  ngOnInit(): void {
    this.loadSales();
  }

  startEdit(saleId: number): void {
    this.editingStates[saleId] = true;
  }

  saveSale(sale: Sale): void {
    const oldSale = this.originalSales[sale.saleId!];

    if (!oldSale) {
      this.editingStates[sale.saleId!] = false;
      return;
    }

    const newQuantity = Number(sale.quantity);
    if (isNaN(newQuantity)) {
      sale.quantity = oldSale.quantity;
    }

    sale.saleDate = new Date(sale.saleDate).toISOString();
    const saleDTO: SaleDTO = {
      saleId: sale.saleId,
      storeId: sale.store.storeId,
      customerId: sale.customer.customerId,
      productId: sale.product.barcode,
      quantity: sale.quantity,
      saleDate: sale.saleDate
    };

    this.saleService.apiSalePut(saleDTO).subscribe(() => {
      this.loadSales();
    });
  }

  deleteSale(saleId: number): void {
    this.saleService.apiSaleIdDelete(saleId).subscribe({
      next: () => {
        this.saleService.apiSaleGet().subscribe(sales => {
          this.sales = sales;
        });
      }
    });
  }

  cancelEdit(saleId: number): void {
    const original = this.originalSales[saleId];
    if (original) {
      const index = this.sales.findIndex(c => c.saleId === saleId);
      if (index !== -1) {
        Object.assign(this.sales[index], original);
      }
    }
    this.editingStates[saleId] = false;
  }

  loadSales(): void {
    this.saleService.apiSaleGet().subscribe((sales) => {
      this.sales = sales.map(sale => ({
        ...sale,
        saleDate: sale.saleDate.substring(0, 16)
      }));
      this.sales.forEach((sale) => {
        this.editingStates[sale.saleId!] = false;
        this.originalSales[sale.saleId!] = {...sale};
      });
    });
    this.productService.apiProductGet().subscribe((products) => {
      this.products = products
    });
    this.storeService.apiStoreGet().subscribe((stores) => {
      this.stores = stores
    });
    this.customerService.apiCustomerGet().subscribe((customers) => {
      this.customers = customers
    });
  }
}

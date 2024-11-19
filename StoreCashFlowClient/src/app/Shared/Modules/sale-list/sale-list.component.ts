import {Component} from '@angular/core';
import {Sale, SaleService} from '../../../api';
import {ActionButtonsComponent} from '../../Components/action-buttons/action-buttons.component';
import {NgForOf} from '@angular/common';
import {ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-sale-list',
  standalone: true,
  imports: [
    ActionButtonsComponent,
    NgForOf,
    ReactiveFormsModule
  ],
  templateUrl: './sale-list.component.html',
  styleUrl: './sale-list.component.css'
})
export class SaleListComponent {
  sales: Sale[] = [];

  constructor(private saleService: SaleService) {
  }

  ngOnInit(): void {
    this.loadSales();
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

  loadSales(): void {
    this.saleService.apiSaleGet().subscribe((sales) =>
      this.sales = sales
    );
  }
}

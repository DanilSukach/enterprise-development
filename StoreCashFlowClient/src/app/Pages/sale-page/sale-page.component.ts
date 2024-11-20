import {Component, ViewChild} from '@angular/core';
import {SaleListComponent} from '../../Shared/Modules/sale-list/sale-list.component';
import {AddSaleComponent} from "../../Shared/Modules/add-sale/add-sale.component";

@Component({
  selector: 'app-sale-page',
  standalone: true,
  imports: [SaleListComponent, AddSaleComponent],
  templateUrl: './sale-page.component.html',
  styleUrl: './sale-page.component.css'
})
export class SalePageComponent {
  currentTitle: string = 'Продажи';
  @ViewChild(SaleListComponent) saleListComponent!: SaleListComponent;

  onSaleAdded() {
    this.saleListComponent.loadSales();
  }
}

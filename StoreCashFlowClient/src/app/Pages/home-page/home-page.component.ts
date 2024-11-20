import {Component} from '@angular/core';
import {AllProductsInStoreComponent} from '../../Shared/Modules/all-products-in-store/all-products-in-store.component';
import {
  StoresWithProductInStokeComponent
} from "../../Shared/Modules/stores-with-product-in-stoke/stores-with-product-in-stoke.component";
import {AveragePriceComponent} from "../../Shared/Modules/average-price/average-price.component";
import {ExpiredProductsComponent} from "../../Shared/Modules/expired-products/expired-products.component";
import {
  StoresWithHighSalesComponent
} from "../../Shared/Modules/stores-with-high-sales/stores-with-high-sales.component";

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [AllProductsInStoreComponent, StoresWithProductInStokeComponent, AveragePriceComponent, ExpiredProductsComponent, StoresWithHighSalesComponent],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent {
  currentTitle: string = 'Главная';
}

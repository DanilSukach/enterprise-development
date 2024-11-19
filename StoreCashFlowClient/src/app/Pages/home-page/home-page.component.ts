import {Component} from '@angular/core';
import {AllProductsInStoreComponent} from '../../Shared/Modules/all-products-in-store/all-products-in-store.component';
import {
  StoresWithProductInStokeComponent
} from "../../Shared/Modules/stores-with-product-in-stoke/stores-with-product-in-stoke.component";
import {AveragePriceComponent} from "../../Shared/Modules/average-price/average-price.component";

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [AllProductsInStoreComponent, StoresWithProductInStokeComponent, AveragePriceComponent],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent {
  currentTitle: string = 'Главная';
}

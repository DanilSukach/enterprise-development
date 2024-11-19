import { Component } from '@angular/core';
import {
  ProductAvailabilityListComponent
} from '../../Shared/Modules/product-availability-list/product-availability-list.component';

@Component({
  selector: 'app-product-availability-page',
  standalone: true,
  imports: [ProductAvailabilityListComponent],
  templateUrl: './product-availability-page.component.html',
  styleUrl: './product-availability-page.component.css'
})
export class ProductAvailabilityPageComponent {
  currentTitle: string = 'Наличие товаров';
}

import {Component, ViewChild} from '@angular/core';
import {
  ProductAvailabilityListComponent
} from '../../Shared/Modules/product-availability-list/product-availability-list.component';
import {
  AddProductAvailabilityComponent
} from "../../Shared/Modules/add-product-availability/add-product-availability.component";

@Component({
  selector: 'app-product-availability-page',
  standalone: true,
  imports: [ProductAvailabilityListComponent, AddProductAvailabilityComponent],
  templateUrl: './product-availability-page.component.html',
  styleUrl: './product-availability-page.component.css'
})
export class ProductAvailabilityPageComponent {
  currentTitle: string = 'Наличие товаров';
  @ViewChild(ProductAvailabilityListComponent) productAvailabilityListComponent!: ProductAvailabilityListComponent;

  onProductAvailabilityAdded() {
    this.productAvailabilityListComponent.loadProductAvailability();
  }
}

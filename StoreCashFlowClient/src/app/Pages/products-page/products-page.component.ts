import {Component, ViewChild} from '@angular/core';
import {ProductListComponent} from '../../Shared/Modules/product-list/product-list.component';
import {AddProductComponent} from "../../Shared/Modules/add-product/add-product.component";


@Component({
  selector: 'app-products-page',
  standalone: true,
  imports: [
    ProductListComponent,
    AddProductComponent
  ],
  templateUrl: './products-page.component.html',
  styleUrl: './products-page.component.css'
})
export class ProductsPageComponent {
  currentTitle: string = 'Продукты';
  @ViewChild(ProductListComponent) productListComponent!: ProductListComponent;

  onProductAdded() {
    this.productListComponent.loadProducts();
  }
}

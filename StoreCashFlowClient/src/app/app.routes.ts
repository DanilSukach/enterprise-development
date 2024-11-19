import {RouterModule, Routes} from '@angular/router';
import {CustomersPageComponent} from './Pages/customers-page/customers-page.component';
import {HomePageComponent} from './Pages/home-page/home-page.component';
import {NgModule} from '@angular/core';
import {StoresPageComponent} from './Pages/stores-page/stores-page.component';
import {ProductsPageComponent} from './Pages/products-page/products-page.component';
import {ProductAvailabilityPageComponent} from './Pages/product-availability-page/product-availability-page.component';
import {SalePageComponent} from './Pages/sale-page/sale-page.component';
import {ErrorPageComponent} from './Pages/error-page/error-page.component';

export const routes: Routes = [
  {path: '', component: HomePageComponent},
  {path: 'customers', component: CustomersPageComponent},
  {path: 'stores', component: StoresPageComponent},
  {path: 'products', component: ProductsPageComponent},
  {path: 'product-availability', component: ProductAvailabilityPageComponent},
  {path: 'sales', component: SalePageComponent},
  {path: '**', component: ErrorPageComponent}
];

@NgModule({ imports: [RouterModule.forRoot(routes)], exports: [RouterModule] })
export class AppRoutingModule { }

import { Component } from '@angular/core';
import {SaleListComponent} from '../../Shared/Modules/sale-list/sale-list.component';

@Component({
  selector: 'app-sale-page',
  standalone: true,
  imports: [SaleListComponent],
  templateUrl: './sale-page.component.html',
  styleUrl: './sale-page.component.css'
})
export class SalePageComponent {
  currentTitle: string = 'Продажи';
}

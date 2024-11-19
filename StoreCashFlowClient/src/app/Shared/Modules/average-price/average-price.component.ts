import {Component, OnInit} from '@angular/core';
import {ProductPriceInfoDto, RequestService, StoreService} from "../../../api";
import {NgForOf, NgIf} from "@angular/common";
import {forkJoin, map} from "rxjs";

@Component({
  selector: 'app-average-price',
  standalone: true,
  imports: [
    NgForOf,
    NgIf
  ],
  templateUrl: './average-price.component.html',
  styleUrl: './average-price.component.css'
})
export class AveragePriceComponent implements OnInit {
  infoWithLocations: { productInfo: ProductPriceInfoDto; location: string }[] = [];

  constructor(private request: RequestService, private storeService: StoreService) {
  }

  ngOnInit() {
    this.loadInfoWithLocations();
  }

  loadInfoWithLocations(): void {
    this.request.apiRequestReturnAveragePriceByGroupAndStoreGet().subscribe((info) => {
      const storeIds = Array.from(new Set(info.map((inf) => inf.storeId)));
      const storeRequests = storeIds.map((storeId) =>
        this.storeService.apiStoreIdGet(storeId!).pipe(
          map((store) => ({storeId, location: store.location}))
        )
      );
      forkJoin(storeRequests).subscribe((stores) => {
        const storeMap = stores.reduce((map, store) => {
          map[store.storeId!] = store.location;
          return map;
        }, {} as { [key: number]: string });

        this.infoWithLocations = info.map((productInfo) => ({
          productInfo,
          location: storeMap[productInfo.storeId!],
        }));
      });
    });
  }
}

import { Component } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { BasketService } from '../services/basket/basket.service';
import { ProductComponent } from '../product/product.component';
import { BasketProductComponent } from '../basket-product/basket-product.component';

@Component({
  selector: 'app-basket',
  standalone: true,
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css',
  imports: [CommonModule, ProductComponent, NgFor, BasketProductComponent],
})
export class BasketComponent {
  constructor(public basketService: BasketService) {}

  totalItemCount(): number {
    let totalItemCount: number = 0;
    for (let index = 0; index < this.basketService.products.length; index++) {
      const element = this.basketService.products[index];
      totalItemCount += element.count;
    }
    return totalItemCount;
  }

  totalPriceCount(): number {
    let totalPrice: number = 0;
    for (let index = 0; index < this.basketService.products.length; index++) {
      const element = this.basketService.products[index];
      totalPrice += element.product.price * element.count;
    }
    return totalPrice;
  }
}

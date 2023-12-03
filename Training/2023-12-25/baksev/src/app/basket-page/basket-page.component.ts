import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketProduct } from '../models/basketProduct';
import { BasketProductComponent } from '../basket-product/basket-product.component';
import { BasketService } from '../services/basket/basket.service';

@Component({
  selector: 'app-basket-page',
  standalone: true,
  templateUrl: './basket-page.component.html',
  styleUrl: './basket-page.component.css',
  imports: [CommonModule, BasketProductComponent],
})
export class BasketPageComponent {
  public productList?: BasketProduct[];

  constructor(private basketService: BasketService) {
    this.productList = basketService.products;
  }
}

import { Component, Input } from '@angular/core';
import { CommonModule, NgIf } from '@angular/common';
import { BasketProduct } from '../models/basketProduct';
import { FormsModule } from '@angular/forms';
import { BasketService } from '../services/basket/basket.service';

@Component({
  selector: 'app-basket-product',
  standalone: true,
  imports: [CommonModule, FormsModule, NgIf],
  templateUrl: './basket-product.component.html',
  styleUrl: './basket-product.component.css',
})
export class BasketProductComponent {
  @Input()
  basketProduct?: BasketProduct;

  @Input()
  inBasketPage: boolean = false;

  constructor(private basketService: BasketService) {}

  countChange() {
    this.basketService.refreshStorage();
  }
  addToBasket(quantity: number) {
    this.basketService.addProduct(this.basketProduct!.product, quantity);
  }

  removeFromBasket() {
    this.basketService.removeProduct(this.basketProduct!.product);
  }
}

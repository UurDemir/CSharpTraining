import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreService } from '../services/store-service/store.service';
import { Product } from '../models/product';
import { ProductListComponent } from '../product-list/product-list.component';

@Component({
  selector: 'app-category-product-list',
  standalone: true,
  imports: [CommonModule, ProductListComponent],
  templateUrl: './category-product-list.component.html',
  styleUrl: './category-product-list.component.css',
})
export class CategoryProductListComponent implements OnInit {
  category?: string;
  products?: Product[];
  @Input()
  set categoryName(category: string) {
    this.category = category;
  }
  constructor(private storeService: StoreService) {}

  ngOnInit(): void {
    this.storeService
      .getCategoryProducts(this.category!)
      .subscribe((products) => {
        this.products = products;
      });
  }
}

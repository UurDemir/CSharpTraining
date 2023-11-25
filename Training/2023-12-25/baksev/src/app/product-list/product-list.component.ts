import { Component, Input, OnInit } from '@angular/core';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { Product } from '../models/product';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, NgFor, NgIf],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css',
})
export class ProductListComponent {
  @Input()
  public productList?: Product[];
}

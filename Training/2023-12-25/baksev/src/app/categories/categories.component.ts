import { Component, OnInit } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { StoreService } from '../services/store-service/store.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [CommonModule, NgFor, RouterLink],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css',
})
export class CategoriesComponent implements OnInit {
  categories?: string[] = [];
  constructor(private storeService: StoreService) {}
  ngOnInit(): void {
    this.storeService.getCategories().subscribe((cats) => {
      this.categories = cats;
    });
  }
}

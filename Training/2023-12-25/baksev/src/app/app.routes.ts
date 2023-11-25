import { Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { CategoriesComponent } from './categories/categories.component';
import { CategoryProductListComponent } from './category-product-list/category-product-list.component';

export const routes: Routes = [
  { path: '', component: CategoriesComponent },
  { path: 'category/:categoryName', component: CategoryProductListComponent },
];

import { Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { CategoriesComponent } from './categories/categories.component';
import { CategoryProductListComponent } from './category-product-list/category-product-list.component';
import { BasketPageComponent } from './basket-page/basket-page.component';
import { OrderPageComponent } from './order-page/order-page.component';

export const routes: Routes = [
  { path: '', component: CategoriesComponent },
  { path: 'category/:categoryName', component: CategoryProductListComponent },
  { path: 'basket', component: BasketPageComponent },
  { path: 'order', component: OrderPageComponent },
];
